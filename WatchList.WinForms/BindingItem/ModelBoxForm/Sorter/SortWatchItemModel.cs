using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Sorter
{
    public class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        public SortWatchItemModel()
            : base(new SortWatchItem())
        {
        }

        public SortWatchItem GetSortItem() => new SortWatchItem() { SortFields = SortFields };
    }
}
