namespace ListWatchedMoviesAndSeries.Model
{
    public class WatchDetailModels
    {
        private const string WatchCinema = "+";
        private const string NotWatchCinema = "-";

        public DateTime? DateWatch { get; set; }

        public string? Grade { get; set; } = null;

        public WatchDetailModels(DateTime? dateWatch, decimal? grade)
        {
            Grade = dateWatch != null ? grade.ToString() : string.Empty;
            DateWatch = dateWatch;
        }

        public string GetView() => DateWatch == null ? NotWatchCinema : WatchCinema;
    }
}
