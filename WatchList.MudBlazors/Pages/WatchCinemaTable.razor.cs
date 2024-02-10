using Microsoft.AspNetCore.Components;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Pages
{
    public partial class WatchCinemaTable
    {
        [Inject] WatchItemService WatchItemService { get; set; } = null!;

        private IEnumerable<WatchItem>? _items;

        private HashSet<WatchItem> _selectedItems = new HashSet<WatchItem>();
        private bool _isSelectItems = true;

        private WatchItemSearchRequest _searchRequest = new WatchItemSearchRequest();
        private PagedList<WatchItem> _pagedList;
        private PageModel _pageModel = new PageModel();

        protected override void OnInitialized()
        {
            _searchRequest = new WatchItemSearchRequest(new FilterItem(), SortField.Title, _pageModel);
            LoadData();
        }

        private void LoadData()
        {
            _pagedList = WatchItemService.GetPage(_searchRequest);
            _items = _pagedList.Items;
            StateHasChanged();
        }

        private void OnSelectItems(HashSet<WatchItem> items)
        {
            _selectedItems = items;
            _isSelectItems = _selectedItems.Count <= 0;
        }
    }
}
