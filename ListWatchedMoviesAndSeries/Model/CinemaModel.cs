using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class CinemaModel : ModelBase
    {
        private Guid _id;
        private string _name;
        private WatchDetail _detail;
        private TypeCinema _type;
        private decimal? _numberSequel;

        public CinemaModel(string name, decimal? numberSequel, TypeCinema type)
            : this(name, numberSequel, null, null, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, TypeCinema type, Guid? id)
            : this(name, numberSequel, null, null, type, id)
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type)
            : this(name, numberSequel, date, grade, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, TypeCinema type, Guid? id)
        {
            _id = id ?? Guid.NewGuid();
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _detail = new WatchDetail(date, grade);
            _numberSequel = numberSequel;
            _type = type;
        }

        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public WatchDetail Detail
        {
            get => _detail;
            set => SetField(ref _detail, value);
        }

        public TypeCinema Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public decimal? NumberSequel
        {
            get => _numberSequel;
            set => SetField(ref _numberSequel, value);
        }

        public WatchItem ToWatchItem()
        {
            return new WatchItem(Name, NumberSequel, Type, Id, Detail.Clone());
        }
    }
}
