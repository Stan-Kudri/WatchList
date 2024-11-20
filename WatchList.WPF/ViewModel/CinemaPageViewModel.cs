using System.Collections.ObjectModel;
using System.Windows;
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
using WatchList.WPF.Views;

namespace WatchList.WPF.ViewModel
{
    public class CinemaPageViewModel : BindingBaseModel
    {
        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly PageService _pageService;

        private readonly SortWatchItemModel _sortField;
        private readonly FilterItemModel _filterItem;
        private readonly ItemSearchRequest _searchRequests;

        private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        private PagedList<WatchItem> _pagedList;
        private readonly bool _isAscending = true;

        private int _curPage;

        private int CurPage
        {
            get => _curPage;
            set
            {
                _curPage = value;
                OnPropertyChanged(nameof(PageDisplayText));
            }
        }

        public CinemaPageViewModel(IMessageBox messageBox,
                            ILogger<WatchItemRepository> logger,
                            WatchItemService watchItemService,
                            SortWatchItemModel sortField,
                            FilterItemModel filterItem,
                            PageService pageService)
        {
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

        public ObservableCollection<WatchItem> WatchItems
        {
            get => _watchItems;
            private set
            {
                if (value == _watchItems)
                {
                    return;
                }

                _watchItems = value;
                OnPropertyChanged(nameof(_watchItems));
            }
        }

        private PageModel Page { get; set; } = new PageModel();

        public string PageDisplayText => $"Page {CurPage} of {_pagedList.PageCount}";

        public List<CinemaModel> PageWatchItems { get; set; }

        public RelayCommandApp MoveToPreviousPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(--Page.Number), _ => _pagedList.HasPreviousPage);
        public RelayCommandApp MoveToFirstPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(1), _ => _pagedList.HasPreviousPage);

        public RelayCommandApp MoveToNextPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(++Page.Number), _ => _pagedList.HasNextPage);
        public RelayCommandApp MoveToLastPage
            => new RelayCommandApp(async _ => await LoadDataAsyncPage(_pagedList.PageCount), _ => _pagedList.HasNextPage);

        public RelayCommandApp MoveAddDataDB
            => new RelayCommandApp(_ => new MergeDatabaseWindow().Show());

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
