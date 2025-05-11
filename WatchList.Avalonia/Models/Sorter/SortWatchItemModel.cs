using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.Avalonia.Models.Sorter
{
    public class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        public SortWatchItemModel()
            : base(new SortWatchItem() { SortFields = new ObservableCollection<SortFieldWatchItem>() { SortFieldWatchItem.Title } })
        {
        }

        public SortWatchItem GetSortItem() => new SortWatchItem() { SortFields = SortFields };

        public override void Clear()
            => SortFields = new ObservableCollection<SortFieldWatchItem>() { SortFieldWatchItem.Title };
    }
}
