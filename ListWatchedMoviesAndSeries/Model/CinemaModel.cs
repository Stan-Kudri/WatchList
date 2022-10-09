using ListWatchedMoviesAndSeries.Model;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class CinemaModel : ModelBase
    {
        private Guid _id;
        private string? _name = null;
        private WatchDetailModels? _detail = null;
        private TypeCinema? _type = null;
        private decimal? _numberSequel = null;

        public Guid? Id
        {
            get => _id;
            set => SetField(ref _id, (Guid)value);
        }

        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public WatchDetailModels? Detail
        {
            get => _detail;
            set => SetField(ref _detail, value);
        }

        public TypeCinema? Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public decimal? NumberSequel
        {
            get => _numberSequel;
            set => SetField(ref _numberSequel, value);
        }

        public CinemaModel(string name, decimal? numberSequel, TypeCinema type) : this(name, numberSequel, null, null, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, TypeCinema type, Guid? id) : this(name, numberSequel, null, null, type, id)
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type) : this(name, numberSequel, date, grade, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type, Guid? id)
        {
            if (name == null)
                throw new ArgumentException("Name cinema not null", nameof(name));
            _id = id ?? Guid.NewGuid();
            _name = name;
            Detail = new WatchDetailModels(date, grade);
            _numberSequel = numberSequel;
            _type = type ?? TypeCinema.Unknown;
        }
    }
}
