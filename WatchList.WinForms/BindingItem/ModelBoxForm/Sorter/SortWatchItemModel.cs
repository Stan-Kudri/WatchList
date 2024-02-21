using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Sorter
{
    public class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        public SortWatchItemModel()
            : base(new SortWatchItem() { SortFields = SortFieldWatchItem.List.Where(e => e == SortFieldWatchItem.Title), })
        {
        }

        public SortWatchItem GetSortItem() => new SortWatchItem() { SortFields = SortFields };
    }
}
