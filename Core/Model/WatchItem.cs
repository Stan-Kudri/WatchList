using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class WatchItem
    {
        private const int NumberTypeAllCinema = 0;
        private const int NumberTypeMove = 1;
        private const int NumberTypeSeries = 2;

        private const string WatchCinema = "+";
        private const string NotWatchCinema = "-";

        private Guid _id;

        [JsonPropertyName("Id")]
        public Guid? Id
        {
            get => _id;
            set => _id = (Guid)value;
        }

        [JsonPropertyName("Name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("Detail")]
        public WatchDetail? Detail { get; set; } = null;

        [JsonPropertyName("Type")]
        [JsonConverter(typeof(SmartEnumValueConverter<TypeCinema, int>))]
        public TypeCinema? Type { get; set; } = null;

        [JsonPropertyName("NumberSequel")]
        public decimal? NumberSequel { get; set; } = null;

        public WatchItem()
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema? type) : this(name, numberSequel, null, null, type, Guid.NewGuid())
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema? type, Guid? Id) : this(name, numberSequel, null, null, type, Id)
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema? type) : this(name, numberSequel, date, grade, type, Guid.NewGuid())
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema? type, Guid? Id)
        {
            if (name == null)
                throw new ArgumentException("Name cinema not null", "Exception");

            _id = Id ?? Guid.NewGuid();
            Name = name;
            Detail = new WatchDetail(date, grade);
            NumberSequel = numberSequel;
            Type = type ?? TypeCinema.Unknown;
        }

        public string GetView() => Detail?.DateWatch == null ? NotWatchCinema : WatchCinema;

        public string GetTypeSequel() => Type == TypeCinema.Movie ? TypeCinema.Movie.Name : TypeCinema.Series.Name;

        public void InstallationType(int numberType)
        {
            if (numberType == NumberTypeMove)
                Type = TypeCinema.Movie;
            else if (numberType == NumberTypeSeries)
                Type = TypeCinema.Series;
            else if (numberType == NumberTypeAllCinema)
                Type = TypeCinema.Unknown;
            else
                throw new ArgumentException("No value number <TypeCinema>.");
        }
    }
}
