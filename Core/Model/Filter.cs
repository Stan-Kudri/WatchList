using Core.ItemFilter;

namespace Core.Model
{
    public class Filter
    {
        public TypeCinemaFilter TypeFilter { get; set; } = TypeCinemaFilter.AllCinema;

        public WatchCinemaFilter WatchFilter { get; set; } = WatchCinemaFilter.AllCinema;

        public Filter(TypeCinemaFilter typeFilter, WatchCinemaFilter watchFilter)
        {
            TypeFilter = typeFilter;
            WatchFilter = watchFilter;
        }
    }
}
