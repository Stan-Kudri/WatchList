using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Filter
{
    public class FilterWatchItem : IEquatable<FilterWatchItem>
    {
        public FilterWatchItem()
        {
        }

        public IEnumerable<TypeCinema> FilterTypeField { get; set; }
            = new HashSet<TypeCinema>(TypeCinema.List.Where(e => e != TypeCinema.AllType));

        public IEnumerable<StatusCinema> FilterStatusField { get; set; }
            = new HashSet<StatusCinema>(StatusCinema.List.Where(e => e != StatusCinema.AllStatus));

        public ObservableCollection<TypeCinema> TypeItems { get; set; }
            = new ObservableCollection<TypeCinema>(TypeCinema.List.Where(e => e != TypeCinema.AllType));

        public ObservableCollection<StatusCinema> StatusItems { get; set; }
            = new ObservableCollection<StatusCinema>(StatusCinema.List.Where(e => e != StatusCinema.AllStatus));

        public TypeCinema TypeFilter { get; set; }

        public StatusCinema StatusFilter { get; set; }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            items = items.Where(x => FilterTypeField.Contains(x.Type));
            items = items.Where(x => FilterStatusField.Contains(x.Status));

            return items;
        }

        public void Clear()
        {
            FilterTypeField = new HashSet<TypeCinema>(TypeCinema.List.Where(e => e != TypeCinema.AllType));
            FilterStatusField = new HashSet<StatusCinema>(StatusCinema.List.Where(e => e != StatusCinema.AllStatus));
        }

        public override int GetHashCode() => HashCode.Combine(FilterTypeField, FilterStatusField);

        public override bool Equals(object? obj) => Equals(obj as FilterWatchItem);

        public bool Equals(FilterWatchItem? other)
            => other != null && FilterTypeField == other.FilterTypeField && FilterStatusField == other.FilterStatusField;
    }
}
