using System.Collections.ObjectModel;
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
            = new ObservableCollection<TypeCinema>(TypeCinema.List);

        public IEnumerable<StatusCinema> FilterStatusField { get; set; }
             = new ObservableCollection<StatusCinema>(StatusCinema.List);

        public List<TypeCinema> TypeItems { get; set; }
            = new List<TypeCinema>(TypeCinema.List);

        public List<StatusCinema> StatusItems { get; set; }
            = new List<StatusCinema>(StatusCinema.List);

        public FilterWatchItem GetFilter() => this;

        public override int GetHashCode() => HashCode.Combine(FilterTypeField, FilterStatusField);

        public override bool Equals(object? obj) => Equals(obj as FilterWatchItem);

        public bool Equals(FilterWatchItem? other)
            => other != null
                && FilterTypeField == other.FilterTypeField
                && FilterStatusField == other.FilterStatusField;
    }
}
