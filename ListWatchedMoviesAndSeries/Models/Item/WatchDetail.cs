namespace ListWatchedMoviesAndSeries.Models.Item
{
    public class WatchDetail
    {
        public DateTime? DateWatch { get; set; }

        public string? Grade { get; set; } = null;

        public WatchDetail(DateTime? dateWatch, decimal? grade)
        {
            Grade = dateWatch != null ? grade.ToString() : string.Empty;
            DateWatch = dateWatch;
        }
    }
}
