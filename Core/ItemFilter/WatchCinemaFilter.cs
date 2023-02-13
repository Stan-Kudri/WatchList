using Ardalis.SmartEnum;
using Core.Model.Item;

namespace Core.ItemFilter
{
    public sealed class WatchCinemaFilter : SmartEnum<WatchCinemaFilter>
    {
        private readonly StatusCinema _status;

        public StatusCinema Status => _status;

        public static readonly WatchCinemaFilter AllCinema = new WatchCinemaFilter("All", 0, StatusCinema.AllStatus);
        public static readonly WatchCinemaFilter ViewedCinema = new WatchCinemaFilter("Viewed Cinema", 1, StatusCinema.Viewed);
        public static readonly WatchCinemaFilter PlannedWatchCinema = new WatchCinemaFilter("Planned Watch Cinema", 2, StatusCinema.Planned);
        public static readonly WatchCinemaFilter LookCinema = new WatchCinemaFilter("Look Cinema", 3, StatusCinema.Look);
        public static readonly WatchCinemaFilter ThrownCinema = new WatchCinemaFilter("Thrown Watch Cinema", 4, StatusCinema.Thrown);

        private WatchCinemaFilter(string name, int value, StatusCinema status) : base(name, value)
        {
            _status = status;
        }
    }
}
