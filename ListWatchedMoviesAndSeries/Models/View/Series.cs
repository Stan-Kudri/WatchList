using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models.View
{
    public class Series : WatchItem
    {
        public decimal? Season { get; set; } = null;

        public Series(string name, decimal? season) : this(name, season, null, null)
        {
        }

        public Series(string name, decimal? season, DateTime? date, decimal? grade)
        {
            Name = name;
            Detail = new WatchDetail(date, grade);
            Season = season;
        }

        public override string GetView() => Detail?.DateWatch == null ? "-" : "+";

        public override string GetSequel() => Season.ToString() ?? string.Empty;
    }
}
