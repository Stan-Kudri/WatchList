using Microsoft.AspNetCore.Components;
using MudBlazor;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.MudBlazors.Dialog;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Pages
{
    public partial class WatchCinemaTable
    {
        [Inject] WatchItemService WatchItemService { get; set; } = null!;
        [Inject] private IDialogService DialogService { get; set; } = null!;

        private readonly PageModel _pageModel = new PageModel();

        private IEnumerable<WatchItem>? _items;
        private HashSet<WatchItem> _selectedItems = new HashSet<WatchItem>();
        private bool _isSelectItems = true;

        private WatchItemSearchRequest _searchRequest = new WatchItemSearchRequest();
        private PagedList<WatchItem>? _pagedList = null;

        protected override void OnInitialized()
        {
            _searchRequest = new WatchItemSearchRequest(new FilterItem(), SortField.Title, _pageModel);
            LoadData();
        }

        private async Task SaveDialogItem(Guid? id = null)
        {
            var parameters = new DialogParameters<WatchItemDialog> { { x => x.Id, id } };
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
            var title = id == null ? "Add Item" : "Edit Item";

            var dialog = await DialogService.ShowAsync<WatchItemDialog>(title, parameters, options);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                LoadData();
            }
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
