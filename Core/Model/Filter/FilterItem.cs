using Core.Model.Filter.Components;
using Core.Model.ItemCinema;
using Core.Model.ItemCinema.Components;

namespace Core.Model.Filter
{
    public class FilterItem : IEquatable<FilterItem>
    {
        public FilterItem()
            : this(TypeFilter.AllCinema, StatusFilter.AllCinema)
        {
        }

        public FilterItem(TypeFilter typeFilter, StatusFilter watchFilter)
        {
            TypeFilter = typeFilter;
            StatusFilter = watchFilter;
        }

        public TypeFilter TypeFilter { get; set; }

        public StatusFilter StatusFilter { get; set; }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            if (TypeFilter.Type != TypeCinema.AllType)
            {
                items = items.Where(x => x.Type == TypeFilter.Type);
            }

            if (StatusFilter.Status != StatusCinema.AllStatus)
            {
                items = items.Where(x => x.Status == StatusFilter.Status);
            }

            return items;
        }

        public override int GetHashCode() => HashCode.Combine(TypeFilter, StatusFilter);

        public override bool Equals(object? obj) => Equals(obj as FilterItem);

        public bool Equals(FilterItem? other)
        {
            if (other == null)
            {
                return false;
            }

            return TypeFilter == other.TypeFilter && StatusFilter == other.StatusFilter;
        }
    }
}
