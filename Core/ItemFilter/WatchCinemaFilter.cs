using Ardalis.SmartEnum;

namespace Core.ItemFilter
{
    public sealed class WatchCinemaFilter : SmartEnum<WatchCinemaFilter>
    {
        private readonly string? _status;

        public string? Status => _status;

        public static readonly WatchCinemaFilter AllCinema = new WatchCinemaFilter("All", 0, null);
        public static readonly WatchCinemaFilter WatchCinema = new WatchCinemaFilter("Watch Cinema", 1, "+");
        public static readonly WatchCinemaFilter NotWatchCinema = new WatchCinemaFilter("Not Watch Cinema", 2, "-");

        private WatchCinemaFilter(string name, int value, string? status) : base(name, value)
        {
            _status = status;
        }
    }
}
