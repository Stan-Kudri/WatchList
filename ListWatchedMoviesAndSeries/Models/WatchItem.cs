using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public abstract class WatchItem
    {
        public string? Name { get; set; } = null;

        public WatchDetail? Detail { get; set; } = null;

        public abstract string GetView();

        public abstract string GetSequel();
    }
}
