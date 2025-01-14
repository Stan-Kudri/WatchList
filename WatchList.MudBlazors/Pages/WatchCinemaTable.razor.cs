using Microsoft.AspNetCore.Components;
using MudBlazor;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.MudBlazors.Extension;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Pages
{
    public partial class WatchCinemaTable
    {
        private const int NonSelectItems = 0;

        private const string MessageNoSelectItems = "No items selected.";
        private const string MessageDeleteItem = "Delete item?";
        private const string MessageDeleteSelectItems = "Delete select items?";

        [Inject] private WatchItemService WatchItemService { get; set; } = null!;
        [Inject] private IDialogService DialogService { get; set; } = null!;
        [Inject] private IMessageBox MessageBoxDialog { get; set; } = null!;
        [Inject] private SortWatchItem SortField { get; set; } = null!;
        [Inject] private IFilterItem FilterWatchItem { get; set; } = null!;

        private readonly PageModel _pageModel = new PageModel();

        private IEnumerable<WatchItem>? _items;
        private HashSet<WatchItem> _selectedItems = new HashSet<WatchItem>();
        private bool _isSelectItems = true;

        private ItemSearchRequest _itemsSearchRequest = null!;
        private PagedList<WatchItem> _pagedList = null!;

        protected override void OnInitialized()
        {
            SortField.Clear();
            FilterWatchItem.Clear();
            _itemsSearchRequest = new ItemSearchRequest(FilterWatchItem, SortField, _pageModel);
            LoadData();
        }

        private async Task UploadData()
        {
            var dialog = await DialogService.UploadDataDialogAsync();
            await dialog.Result;
            LoadData();
        }

        private async Task SaveItemDialog(Guid? id = null)
        {
            var dialog = await DialogService.SaveItemDialogAsync(id);
            await dialog.Result;
            LoadData();
        }

        private async Task RemoveItemsDialog()
        {
            if (_selectedItems.Count <= NonSelectItems)
            {
                await MessageBoxDialog.ShowWarning(MessageNoSelectItems);
                return;
            }

            if (!await MessageBoxDialog.ShowQuestion(MessageDeleteSelectItems))
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
            if (!await MessageBoxDialog.ShowQuestion(MessageDeleteItem))
            {
                return;
            }

            WatchItemService.Remove(id);
            LoadData();
        }

        private void LoadData()
        {
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
            FilterWatchItem.Clear();
            SortField.Clear();
            LoadData();
        }

        private void PageChanged(int i)
        {
            _pageModel.Number = i;
            LoadData();
        }

        private void OnToggledChanged(bool toggled)
        {
            _itemsSearchRequest.IsAscending = toggled;
            LoadData();
        }

        private string GetMultiSelectionTypeCinema(List<string> selectedValues)
            => selectedValues.Count == TypeCinema.List.Count
            ? "All type"
            : string.Join(',', selectedValues);

        private string GetMultiSelectionStatusCinema(List<string> selectedValues)
            => selectedValues.Count == StatusCinema.List.Count
            ? "All status"
            : string.Join(',', selectedValues);
    }
}
