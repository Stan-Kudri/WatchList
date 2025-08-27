using WatchList.Core.Extension;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Filter
{
    public interface IFilterItem
    {
        IEnumerable<TypeCinema> FilterTypeField { get; set; }

        IEnumerable<StatusCinema> FilterStatusField { get; set; }

        List<TypeCinema> TypeItems { get; set; }

        List<StatusCinema> StatusItems { get; set; }

        IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            items = items.Where(x => FilterTypeField.Contains(x.Type));
            items = items.Where(x => FilterStatusField.Contains(x.Status));
            return items;
        }

        void Clear()
        {
            FilterTypeField = TypeCinema.List.ToObservableCollection();
            FilterStatusField = StatusCinema.List.ToObservableCollection();
        }

        FilterWatchItem GetFilter();
    }
}
