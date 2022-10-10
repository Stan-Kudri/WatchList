using System.Text.Json.Serialization;

namespace ListWatchedMoviesAndSeries.Models.Item
{
    public class WatchDetail
    {
        private const string WatchCinema = "+";
        private const string NotWatchCinema = "-";

        [JsonPropertyName("DateWatch")]
        public DateTime? DateWatch { get; set; }

        [JsonPropertyName("Grade")]
        public string? Grade { get; set; } = null;

        [JsonIgnore]
        public string Watch => DateWatch == null ? NotWatchCinema : WatchCinema;

        public WatchDetail()
        {
        }

        public WatchDetail(DateTime? dateWatch, decimal? grade)
        {
            Grade = dateWatch != null ? grade.ToString() : string.Empty;
            DateWatch = dateWatch;
        }

        public string GetWatchData() => DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;

        public bool ValidDateField() => DateWatch != null && Watch == WatchCinema;
    }
}