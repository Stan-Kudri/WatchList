using Core.ItemFilter;
using ListWatchedMoviesAndSeries.Models;

namespace Core.Model
{
    public class WatchItemFilter : IEquatable<WatchItemFilter>
    {
        public TypeCinemaFilter TypeFilter { get; set; }

        public WatchCinemaFilter WatchFilter { get; set; }

        public WatchItemFilter() : this(TypeCinemaFilter.AllCinema, WatchCinemaFilter.AllCinema)
        {
        }

        public WatchItemFilter(TypeCinemaFilter typeFilter, WatchCinemaFilter watchFilter)
        {
            TypeFilter = typeFilter;
            WatchFilter = watchFilter;
        }

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items)
        {
            if (TypeFilter.Type != TypeCinemaFilter.AllCinema)
            {
                items = items.Where(x => x.Type == TypeFilter.Type);
            }
            if (WatchFilter.Status != WatchCinemaFilter.AllCinema)
            {
                items = items.Where(x => x.Status == WatchFilter.Status);
            }

            return items;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeFilter, WatchFilter);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as WatchItemFilter);
        }

        public bool Equals(WatchItemFilter? other)
        {
            if (other == null)
                return false;

            return TypeFilter == other.TypeFilter && WatchFilter == other.WatchFilter;
        }
    }
}