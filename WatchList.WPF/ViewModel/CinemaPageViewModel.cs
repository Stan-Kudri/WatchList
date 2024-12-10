using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Commands;
using WatchList.WPF.Data;
using WatchList.WPF.Extension;
using WatchList.WPF.Models;
using WatchList.WPF.Models.Filter;
using WatchList.WPF.Models.Sorter;
using WatchList.WPF.ViewModel.ItemsView;
using WatchList.WPF.Views;
using WatchList.WPF.Views.CinemaView;

namespace WatchList.WPF.ViewModel
{
    public class CinemaPageViewModel : BindableBase
    {
        private const string HighlightTheDesiredLine = "No items selected.";
        private const string NotSelectSingleItemLine = "Select one item.";

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly PageService _pageService;

        private readonly SortWatchItemModel _sortField;
        private readonly FilterItemModel _filterItem;
        private readonly ItemSearchRequest _searchRequests;

        private readonly bool _isAscending = true;

        private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        private PagedList<WatchItem> _pagedList;

        private WatchItem _selectItem;
        private IList _selectItems = new ArrayList();
        private int _curPage;

        private int CurPage
        {
            get => _curPage;
            set => SetValue(ref _curPage, value);
        }

        public CinemaPageViewModel(IMessageBox messageBox,
                            ILogger<WatchItemRepository> logger,
                            IServiceProvider serviceProvider,
                            WatchItemService watchItemService,
                            SortWatchItemModel sortField,
                            FilterItemModel filterItem,
                            PageService pageService)
        {
            _serviceProvider = serviceProvider;
            _messageBox = messageBox;
            _logger = logger;
            _itemService = watchItemService;
            _sortField = sortField;
            _filterItem = filterItem;
            _pageService = pageService;
            _searchRequests = new ItemSearchRequest(_filterItem, _sortField.GetSortItem(), Page.GetPage(), _isAscending);
            _pagedList = _itemService.GetPage(_searchRequests);
            CurPage = Page.Number;
            LoadDataAsync();
        }

        public WatchItem SelectItem
        {
            get => _selectItem;
            set => SetValue(ref _selectItem, value);
        }

        public IList SelectItems
        {
            get => _selectItems;
            set => SetValue(ref _selectItems, value);
        }

        public ObservableCollection<WatchItem> WatchItems
        {
            get => _watchItems;
            private set => SetValue(ref _watchItems, value);
        }

        private PageModel Page { get; set; } = new PageModel();

        public string PageDisplayText => $"Page {CurPage} of {_pagedList.PageCount}";

        public List<WatchItemCreator> PageWatchItems { get; set; }

        public RelayCommandApp MoveToPreviousPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(--Page.Number), _ => _pagedList.HasPreviousPage);
        public RelayCommandApp MoveToFirstPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(1), _ => _pagedList.HasPreviousPage);

        public RelayCommandApp MoveToNextPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(++Page.Number), _ => _pagedList.HasNextPage);
        public RelayCommandApp MoveToLastPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(_pagedList.PageCount), _ => _pagedList.HasNextPage);

        public RelayCommandApp AddItemCommand
            => new RelayCommandApp(async async => await MoveAddItem());
        public RelayCommandApp EditItemCommand
            => new RelayCommandApp(async async => await EditItem());
        public RelayCommandApp DeleteItemsCommand
            => new RelayCommandApp(async async => await DeleteItems());
        public RelayCommandApp AddDataDBCommand
            => new RelayCommandApp(async async => await MoveAddData());

        private async Task MoveAddItem()
        {
            var viewModel = _serviceProvider.GetRequiredService<AddCinemaViewModel>();
            viewModel.InitializeDefaultValue();
            var addWindow = new WatchCinemaWindow(viewModel);

            if (addWindow.ShowDialog() != true)
            {
                return;
            }

            await LoadDataAsync();
        }

        private async Task EditItem()
        {
            if (SelectItems.Count != 1)
            {
                await _messageBox.ShowInfo(NotSelectSingleItemLine);
                return;
            }

            var viewModel = _serviceProvider.GetRequiredService<EditCinemaViewModel>();
            viewModel.InitializeDefaultValue(SelectItem);
            var editWindow = new WatchCinemaWindow(viewModel);

            if (editWindow.ShowDialog() != true)
            {
                return;
            }

            await LoadDataAsync();
        }

        private async Task DeleteItems()
        {
            if (SelectItems.Count == 0)
            {
                await _messageBox.ShowInfo(HighlightTheDesiredLine);
                return;
            }

            if (!await _messageBox.ShowQuestion("Delete select items?"))
            {
                return;
            }

            foreach (var item in SelectItems)
            {
                var isWatchItem = item as WatchItem;
                if (isWatchItem != null)
                {
                    _itemService.Remove(isWatchItem.Id);
                }
            }

            await LoadDataAsync();
        }

        private async Task MoveAddData()
        {
            var addDataWindow = new MergeDatabaseWindow();
            if (addDataWindow.ShowDialog() != true)
            {
                return;
            }

            await LoadDataAsync();
        }

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                UpdataSearchRequests();
                _pagedList = _itemService.GetPage(_searchRequests);

                WatchItems.UppdataItems(_pagedList.Items);

                if (IsNotFirstPageEmpty())
                {
                    Page.Number -= 1;
                    await LoadDataAsync();
                }
            }
            catch (Exception error)
            {
                await _messageBox.ShowError(error.Message);
            }
        }

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsyncPage(int pageNumber)
        {
            Page.Number = CurPage = pageNumber;
            await LoadDataAsync();
        }

        /// <summary>
        /// Updating table data by Filter and Sorting.
        /// </summary>
        private void UpdataSearchRequests()
        {
            _searchRequests.Page = Page.GetPage();
            _searchRequests.Sort = _sortField.GetSortItem();
            _searchRequests.Filter = _filterItem.GetFilter();
            _searchRequests.IsAscending = _isAscending;
        }

        /// <summary>
        /// The method checks if the page is empty.
        /// </summary>
        /// <returns>
        /// True - The page contains no elements and is not the first.
        /// </returns>
        private bool IsNotFirstPageEmpty() => _pagedList.Count == 0 && Page.Number != 1;

        private async void Window_Loaded(object sender, RoutedEventArgs e) => await LoadDataAsync();
    }
}
