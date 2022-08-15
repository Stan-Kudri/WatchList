using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models.View
{
    public class Movie : WatchItem
    {
        public decimal? Part { get; set; } = null;

        public Movie(string name) : this(name, null, null)
        {

        }

        public Movie(string name, DateTime? date, decimal? grade)
        {
            Name = name;
            Detail = new WatchDetail(date, grade);
        }

        public override string GetView() => Detail?.DateWatch == null ? "-" : "+";

        public override string GetSequel() => Part.ToString() ?? string.Empty;
    }
}
