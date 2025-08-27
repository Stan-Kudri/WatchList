using WatchList.Core.Extension;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Filter
{
    public class FilterWatchItem : IEquatable<FilterWatchItem>, IFilterItem
    {
        public FilterWatchItem()
        {
        }

        public FilterWatchItem(IEnumerable<TypeCinema> filterTypeField, IEnumerable<StatusCinema> filterStatusField)
        {
            FilterTypeField = filterTypeField;
            FilterStatusField = filterStatusField;
        }

        public IEnumerable<TypeCinema> FilterTypeField { get; set; }
            = TypeCinema.List.ToObservableCollection();

        public IEnumerable<StatusCinema> FilterStatusField { get; set; }
             = StatusCinema.List.ToObservableCollection();

        public List<TypeCinema> TypeItems { get; set; } = TypeCinema.List.ToListCollection();

        public List<StatusCinema> StatusItems { get; set; } = StatusCinema.List.ToListCollection();

        public FilterWatchItem GetFilter() => this;

        public override int GetHashCode() => HashCode.Combine(FilterTypeField, FilterStatusField);

        public override bool Equals(object? obj) => Equals(obj as FilterWatchItem);

        public bool Equals(FilterWatchItem? other)
            => other != null
                && FilterTypeField == other.FilterTypeField
                && FilterStatusField == other.FilterStatusField;
    }
}
