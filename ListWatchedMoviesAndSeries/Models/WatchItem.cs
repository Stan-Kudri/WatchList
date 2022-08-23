using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class WatchItem : ModelsBase
    {
        public const string WatchCinema = "+";
        public const string NotWatchCinema = "-";

        private string? _name = null;
        private WatchDetail? _detail = null;
        private TypeCinema? _type = null;
        private decimal? _numberSequel = null;

        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public WatchDetail? Detail
        {
            get => _detail;
            set => SetField(ref _detail, value);
        }

        public decimal? NumberSequel
        {
            get => _numberSequel;
            set => SetField(ref _numberSequel, value);
        }

        public TypeCinema? Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public WatchItem(string name, decimal? numberSequel, TypeCinema type) : this(name, numberSequel, null, null, type)
        {
        }

        public WatchItem(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type)
        {
            if (name == null)
                throw new ArgumentException("Name cinema not null", "Exception");

            _name = name;
            Detail = new WatchDetail(date, grade);
            _numberSequel = numberSequel;
            _type = type;
        }

        public string GetView() => Detail?.DateWatch == null ? NotWatchCinema : WatchCinema;

        public string GetTypeSequel() => _type == TypeCinema.Movie ? TypeCinema.Movie.Name : TypeCinema.Series.Name;
    }
}
