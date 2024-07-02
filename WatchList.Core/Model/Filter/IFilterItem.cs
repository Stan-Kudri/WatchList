using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Filter
{
    public interface IFilterItem
    {
        IEnumerable<TypeCinema> FilterTypeField { get; set; }

        IEnumerable<StatusCinema> FilterStatusField { get; set; }

        ObservableCollection<TypeCinema> TypeItems { get; set; }

        ObservableCollection<StatusCinema> StatusItems { get; set; }

        IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            items = items.Where(x => FilterTypeField.Contains(x.Type));
            items = items.Where(x => FilterStatusField.Contains(x.Status));
            return items;
        }

        void Clear()
        {
            FilterTypeField = new HashSet<TypeCinema>(TypeCinema.List);
            FilterStatusField = new HashSet<StatusCinema>(StatusCinema.List);
        }

        FilterWatchItem GetFilter();
    }
}
