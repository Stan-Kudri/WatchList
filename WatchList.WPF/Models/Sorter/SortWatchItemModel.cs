using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.WPF.Models.Sorter
{
    public class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        public SortWatchItemModel()
            : base(new SortWatchItem() { SortFields = SortFieldWatchItem.List.Where(e => e == SortFieldWatchItem.Title), })
        {
        }

        public SortWatchItem GetSortItem() => new SortWatchItem() { SortFields = SortFields };

        public override void Clear()
            => SortFields = SortFieldWatchItem.List.Where(e => e == SortFieldWatchItem.Title);
    }
}
