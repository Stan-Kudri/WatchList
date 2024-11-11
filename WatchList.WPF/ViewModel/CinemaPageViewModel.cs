using System.Windows;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.WPF.Commands;
using WatchList.WPF.Data;
using WatchList.WPF.Models;
using WatchList.WPF.Models.Filter;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.Sorter;

namespace WatchList.WPF.ViewModel
{
    public class CinemaPageViewModel
    {
        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly DownloadDataService _downloadDataService;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly PageService _pageService;

        private readonly SortWatchItemModel _sortField;
        private readonly FilterItemModel _filterItem;
        private readonly ItemSearchRequest _searchRequests;

        private readonly ModelLoadDataDB _modelLoadDataDB;

        private PagedList<WatchItem> _pagedList;
        private bool _isAscending = true;

        public CinemaPageViewModel(IMessageBox messageBox,
                            DownloadDataService downloadDataService,
                            ILogger<WatchItemRepository> logger,
                            WatchItemService watchItemService,
                            SortWatchItemModel sortField,
                            FilterItemModel filterItem,
                            PageService pageService,
                            ModelLoadDataDB modelLoadDataDB)
        {
            _messageBox = messageBox;
            _downloadDataService = downloadDataService;
            _logger = logger;
            _itemService = watchItemService;
            _sortField = sortField;
            _filterItem = filterItem;
            _pageService = pageService;
            _searchRequests = new ItemSearchRequest(_filterItem, _sortField.GetSortItem(), Page.GetPage(), _isAscending);
            _pagedList = _itemService.GetPage(_searchRequests);
            _modelLoadDataDB = modelLoadDataDB;
        }

        private PageModel Page { get; set; } = new PageModel();

        public string PageDisplayText => $"Page {_pagedList.PageNumber} of {_pagedList.PageCount}";

        public List<WatchItem> GetPageWatchItems => _pagedList.Items;

        public RelayCommand MoveAddDataDB
            => new RelayCommand(_ => _modelLoadDataDB.CanLoadDataFromDB());

        /// <summary>
        /// Load data in table.
        /// </summary>
        private async Task LoadDataAsync()
        {
            try
            {
                UpdataSearchRequests();
                _pagedList = _itemService.GetPage(_searchRequests);
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
        private bool IsNotFirstPageEmpty()
            => _pagedList.Count == 0 && Page.Number != 1;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
            => await LoadDataAsync();
    }
}
