using System.Collections;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.WPF.Commands;
using WatchList.WPF.Extension;
using WatchList.WPF.Models;
using WatchList.WPF.Models.Sorter;
using WatchList.WPF.Views;

namespace WatchList.WPF.ViewModel
{
    public partial class CinemaPageViewModel : ObservableObject
    {
        private const string HighlightTheDesiredLine = "No items selected.";
        private const string NotSelectSingleItemLine = "Select one item.";

        private readonly WatchItemService _itemService;
        private readonly IMessageBox _messageBox;
        private readonly CinemaWindowCreator _cinemaWindowCreator;

        private readonly ItemSearchRequest _searchRequests;

        private PagedList<WatchItem> _pagedList;

        [ObservableProperty] private string _pageDisplayText = string.Empty;

        [ObservableProperty] private PageModel _page;

        [ObservableProperty] private IFilterItem _filterItem;
        [ObservableProperty] private SortWatchItemModel _sortField;
        [ObservableProperty] private TypeSortFields _typeSortFields;

        [ObservableProperty] private ObservableCollection<WatchItem> _watchItems = new ObservableCollection<WatchItem>();

        [ObservableProperty] private WatchItem _selectItem;
        [ObservableProperty] private IList _selectItems = new ArrayList();

        public CinemaPageViewModel(IMessageBox messageBox,
                            WatchItemService watchItemService,
                            SortWatchItemModel sortFieldModel,
                            IFilterItem filterItemModel,
                            TypeSortFields typeSortFieldsModel,
                            PageModel pageModel,
                            CinemaWindowCreator cinemaWindowCreator)
        {
            _messageBox = messageBox;
            _itemService = watchItemService;
            _cinemaWindowCreator = cinemaWindowCreator;
            SortField = sortFieldModel;
            FilterItem = filterItemModel;
            TypeSortFields = typeSortFieldsModel;
            Page = pageModel;

            TypeSortFields.IsAscending = true;
            _searchRequests = new ItemSearchRequest(FilterItem, SortField.GetSortItem(), Page.GetPage(), TypeSortFields.IsAscending);
            _pagedList = _itemService.GetPage(_searchRequests);
            _ = LoadDataAsync();
        }

        public RelayCommandApp MoveToPreviousPageCommand
            => new(async _ => await LoadDataAsyncPage(--Page.Number), _ => _pagedList.HasPreviousPage);

        public RelayCommandApp MoveToFirstPageCommand
            => new(async _ => await LoadDataAsyncPage(1), _ => _pagedList.HasPreviousPage);

        public RelayCommandApp MoveToNextPageCommand
            => new(async _ => await LoadDataAsyncPage(++Page.Number), _ => _pagedList.HasNextPage);

        public RelayCommandApp MoveToLastPageCommand
            => new(async _ => await LoadDataAsyncPage(_pagedList.PageCount), _ => _pagedList.HasNextPage);

        [RelayCommand]
        private async Task UseFilter() => await LoadDataAsync();

        [RelayCommand]
        private async Task ClearFilter()
        {
            FilterItem.Clear();
            SortField.Clear();
            await LoadDataAsync();
        }

        [RelayCommand]
        private async Task MoveAddItem()
        {
            var addWindow = _cinemaWindowCreator.AddItemWindow();

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

            var editWindow = _cinemaWindowCreator.EditItemWindow(SelectItem);

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

            _itemService.RemoveRangeWatchItem(SelectItems);
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
                PageDisplayText = _pagedList.HasEmptyPage
                                ? string.Empty
                                : $"Page {_pagedList.PageNumber} of {_pagedList.PageCount}";
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
            _searchRequests.Sort = SortField.GetSortItem();
            _searchRequests.Filter = FilterItem.GetFilter();
            _searchRequests.IsAscending = TypeSortFields.IsAscending;
        }
    }
}
