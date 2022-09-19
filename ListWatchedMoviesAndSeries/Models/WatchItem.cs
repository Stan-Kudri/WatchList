using Ardalis.SmartEnum.SystemTextJson;
using ListWatchedMoviesAndSeries.Models.Item;
using System.Text.Json.Serialization;

namespace ListWatchedMoviesAndSeries.Models
{
    public class WatchItem : ModelsBase
    {
        public const string WatchCinema = "+";
        public const string NotWatchCinema = "-";

        private Guid _id;
        private string? _name = null;
        private WatchDetail? _detail = null;
        private TypeCinema? _type = null;
        private decimal? _numberSequel = null;

        [JsonPropertyName("Id")]
        public Guid? Id
        {
            get => _id;
            set => SetField(ref _id, (Guid)value);
        }

        [JsonPropertyName("Name")]
        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        [JsonPropertyName("Detail")]
        public WatchDetail? Detail
        {
            get => _detail;
            set => SetField(ref _detail, value);
        }

        [JsonPropertyName("Type")]
        [JsonConverter(typeof(SmartEnumValueConverter<TypeCinema, int>))]
        public TypeCinema? Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        [JsonPropertyName("NumberSequel")]
        public decimal? NumberSequel
        {
            get => _numberSequel;
            set => SetField(ref _numberSequel, value);
        }

        private WatchItem()
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema type) : this(name, numberSequel, null, null, type, Guid.NewGuid().ToString())
        {
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema type, string Id) : this(name, numberSequel, null, null, type, Id)
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type) : this(name, numberSequel, date, grade, type, Guid.NewGuid().ToString())
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type, string Id)
        {
            if (name == null)
                throw new ArgumentException("Name cinema not null", "Exception");

            _id = Id != string.Empty ? Guid.Parse(Id) : Guid.NewGuid();
            _name = name;
            Detail = new WatchDetail(date, grade);
            _numberSequel = numberSequel;
            _type = type != null ? type : TypeCinema.Unknown;
        }

        public string GetView() => Detail?.DateWatch == null ? NotWatchCinema : WatchCinema;

        public string GetTypeSequel() => _type == TypeCinema.Movie ? TypeCinema.Movie.Name : TypeCinema.Series.Name;
    }
}
