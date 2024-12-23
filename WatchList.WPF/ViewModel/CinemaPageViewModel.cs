using System.Collections;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Commands;
using WatchList.WPF.Data;
using WatchList.WPF.Extension;
using WatchList.WPF.Models;
using WatchList.WPF.Models.Sorter;
using WatchList.WPF.ViewModel.ItemsView;
using WatchList.WPF.Views;
using WatchList.WPF.Views.CinemaView;

namespace WatchList.WPF.ViewModel
{
    public partial class CinemaPageViewModel : BindableBase
    {
        private const string HighlightTheDesiredLine = "No items selected.";
        private const string NotSelectSingleItemLine = "Select one item.";

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly PageService _pageService;

        private readonly ItemSearchRequest _searchRequests;

        private string _pageDisplayText = string.Empty;

        private IFilterItem _filterItem;
        private SortWatchItemModel _sortField;
        private TypeSortFields _typeSortFields;

        private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        private PagedList<WatchItem> _pagedList;

        private WatchItem _selectItem;
        private IList _selectItems = new ArrayList();

        public CinemaPageViewModel(IMessageBox messageBox,
                            ILogger<WatchItemRepository> logger,
                            IServiceProvider serviceProvider,
                            WatchItemService watchItemService,
                            SortWatchItemModel sortField,
                            IFilterItem filterItem,
                            PageService pageService,
                            TypeSortFields typeSortFields)
        {
            _serviceProvider = serviceProvider;
            _messageBox = messageBox;
            _logger = logger;
            _itemService = watchItemService;
            _sortField = sortField;
            _filterItem = filterItem;
            _pageService = pageService;
            _typeSortFields = typeSortFields;

            TypeSortField.IsAscending = true;
            _searchRequests = new ItemSearchRequest(_filterItem, SortItemModel.GetSortItem(), Page.GetPage(), _typeSortFields.IsAscending);
            _pagedList = _itemService.GetPage(_searchRequests);
            LoadDataAsync();
        }

        private PageModel Page { get; set; } = new PageModel();

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

        public IFilterItem FilterItemModel
        {
            get => _filterItem;
            set => SetValue(ref _filterItem, value);
        }

        public SortWatchItemModel SortItemModel
        {
            get => _sortField;
            set => SetValue(ref _sortField, value);
        }

        public TypeSortFields TypeSortField
        {
            get => _typeSortFields;
            set => SetValue(ref _typeSortFields, value);
        }

        public string PageDisplayText
        {
            get => _pageDisplayText;
            set => SetValue(ref _pageDisplayText, value);
        }

        public RelayCommandApp MoveToPreviousPage
            => new(async _ => await LoadDataAsyncPage(--Page.Number), _ => _pagedList.HasPreviousPage);
        public RelayCommandApp MoveToFirstPage
            => new(async _ => await LoadDataAsyncPage(1), _ => _pagedList.HasPreviousPage);

        public RelayCommandApp MoveToNextPage
            => new(async _ => await LoadDataAsyncPage(++Page.Number), _ => _pagedList.HasNextPage);
        public RelayCommandApp MoveToLastPage
            => new(async _ => await LoadDataAsyncPage(_pagedList.PageCount), _ => _pagedList.HasNextPage);

        [RelayCommand]
        private async Task UseFilter() => await LoadDataAsync();

        [RelayCommand]
        private async Task ClearFilter()
        {
            FilterItemModel.Clear();
            SortItemModel.Clear();
            await LoadDataAsync();
        }

        [RelayCommand]
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

        [RelayCommand]
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

        [RelayCommand]
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

        [RelayCommand]
        private async Task AddData()
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

                PageDisplayText = $"Page {_pagedList.PageNumber} of {_pagedList.PageCount}";
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
            Page.Number = pageNumber;
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
            _searchRequests.IsAscending = _typeSortFields.IsAscending;
        }

        /// <summary>
        /// The method checks if the page is empty.
        /// </summary>
        /// <returns>
        /// True - The page contains no elements and is not the first.
        /// </returns>
        private bool IsNotFirstPageEmpty() => _pagedList.Count == 0 && Page.Number != 1;
    }
}
