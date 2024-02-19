using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Sorter
{
    public class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        public SortWatchItemModel()
            : base(new SortItem<WatchItem, SortFieldWatchItem>())
        {
        }

        public SortItem<WatchItem, SortFieldWatchItem> GetSortItem() => new SortItem<WatchItem, SortFieldWatchItem>(SortFields);
    }
}
