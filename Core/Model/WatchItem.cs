using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class WatchItem
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } = null;

        public WatchDetail? Detail { get; set; } = new WatchDetail();

        [JsonPropertyName("TypeCinema")]
        public TypeCinema? Type { get; set; } = null;

        public decimal? NumberSequel { get; set; } = null;

        public WatchItem()
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema? type) : this(name, numberSequel, null, null, type, Guid.NewGuid())
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema? type, Guid? id) : this(name, numberSequel, null, null, type, id)
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema? type) : this(name, numberSequel, date, grade, type, Guid.NewGuid())
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema? type, Guid? id)
        {
            if (name == null)
                throw new ArgumentException("Name cinema not null", nameof(name));

            Id = id ?? Guid.NewGuid();
            Name = name;
            Detail = new WatchDetail(date, grade);
            NumberSequel = numberSequel;
            Type = type ?? TypeCinema.Unknown;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Detail, Type, NumberSequel);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as WatchItem);
        }

        public bool Equals(WatchItem? other) => other != null
            && Id == other.Id
            && Name == other.Name
            && Detail != null
            && Detail.Equals(other.Detail)
            && Type == other.Type
            && NumberSequel == other.NumberSequel;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });
        }
    }
}
