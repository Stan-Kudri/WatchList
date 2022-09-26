using System.Text.Json.Serialization;

namespace ListWatchedMoviesAndSeries.Models.Item
{
    public class WatchDetail
    {
        [JsonPropertyName("DateWatch")]
        public DateTime? DateWatch { get; set; }

        [JsonPropertyName("Grade")]
        public string? Grade { get; set; } = null;

        public WatchDetail()
        {
        }

        public WatchDetail(DateTime? dateWatch, decimal? grade)
        {
            Grade = dateWatch != null ? grade.ToString() : string.Empty;
            DateWatch = dateWatch;
        }
    }
}
