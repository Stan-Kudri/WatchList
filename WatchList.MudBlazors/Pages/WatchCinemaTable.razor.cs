using Microsoft.AspNetCore.Components;
using MudBlazor;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.MudBlazors.Dialog;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Pages
{
    public partial class WatchCinemaTable
    {
        private const int NonSelectItems = 0;

        private const string MessageNoSelectItems = "No items selected.";

        [Inject] WatchItemService WatchItemService { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;
        [Inject] IMessageBox MessageBoxDialog { get; set; } = null!;
        [Inject] SortWatchItem<WatchItem, SortFieldWatchItem> SortField { get; set; } = null!;

        private readonly PageModel _pageModel = new PageModel();

        private IEnumerable<WatchItem>? _items;
        private HashSet<WatchItem> _selectedItems = new HashSet<WatchItem>();
        private bool _isSelectItems = true;

        private ItemSearchRequest _itemsSearchRequest = new ItemSearchRequest();
        private PagedList<WatchItem>? _pagedList = null;

        private FilterModel Filter { get; set; } = new FilterModel();
        //private SortModel Sort { get; set; } = new SortModel();

        protected override void OnInitialized()
        {
            _itemsSearchRequest = new ItemSearchRequest(new FilterItem(), SortField, _pageModel);
            LoadData();
        }

        private async Task SaveItemDialog(Guid? id = null)
        {
            var parameters = new DialogParameters<WatchItemDialog> { { x => x.Id, id } };
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true };
            var title = id == null ? "Add Item" : "Edit Item";

            var dialog = await DialogService.ShowAsync<WatchItemDialog>(title, parameters, options);
            var result = await dialog.Result;
            LoadData();
        }

        private async Task RemoveItemsDialog()
        {
            if (_selectedItems.Count <= NonSelectItems)
            {
                await MessageBoxDialog.ShowWarning(MessageNoSelectItems);
                return;
            }

            if (!await MessageBoxDialog.ShowQuestion("Delete selecte items?"))
            {
                return;
            }

            foreach (var item in _selectedItems)
            {
                WatchItemService.Remove(item.Id);
            }

            LoadData();
        }

        private async Task RemoveItemDialog(Guid id)
        {
            if (!await MessageBoxDialog.ShowQuestion("Delete selecte items?"))
            {
                return;
            }

            WatchItemService.Remove(id);
            LoadData();
        }

        private void LoadData()
        {
            _itemsSearchRequest.Filter = Filter.GetFilter();
            _pagedList = WatchItemService.GetPage(_itemsSearchRequest);
            _items = _pagedList.Items;
            StateHasChanged();
        }

        private void OnSelectItems(HashSet<WatchItem> items)
        {
            _selectedItems = items;
            _isSelectItems = _selectedItems.Count <= 0;
        }

        private void ClearFilter()
        {
            _itemsSearchRequest.IsAscending = true;
            Filter.Clear();
            SortField.Clear();
            LoadData();
        }

        public void OnToggledChanged(bool toggled)
        {
            _itemsSearchRequest.IsAscending = toggled;
            LoadData();
        }
    }
}
