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

        public Guid Id { get; set; }

        public string? Name { get; set; } = null;

        public WatchDetail Detail { get; set; } = new WatchDetail();

        [JsonConverter(typeof(SmartEnumValueConverter<TypeCinema, int>))]
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

        public void InitializType(int numberType)
        {
            if (numberType == NumberTypeMove)
                Type = TypeCinema.Movie;
            else if (numberType == NumberTypeSeries)
                Type = TypeCinema.Series;
            else if (numberType == NumberTypeAllCinema)
                Type = TypeCinema.Unknown;
            else
                throw new ArgumentException("No value number <TypeCinema>.", nameof(numberType));
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Detail.GetHashCode, Type, NumberSequel);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as WatchItem);
        }

        public bool Equals(WatchItem? other)
        {
            return other != null && Id == other.Id && Name == other.Name && Detail.Equals(other.Detail) && Type == other.Type && NumberSequel == other.NumberSequel;
        }
    }
}
