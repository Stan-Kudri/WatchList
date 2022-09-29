namespace ListWatchedMoviesAndSeries.Model
{
    public class WatchDetailModels
    {
        public DateTime? DateWatch { get; set; }

        public string? Grade { get; set; } = null;

        public WatchDetailModels(DateTime? dateWatch, decimal? grade)
        {
            Grade = dateWatch != null ? grade.ToString() : string.Empty;
            DateWatch = dateWatch;
        }
    }
}
