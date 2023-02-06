using Core.Model.Item;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class CinemaModel : ModelBase
    {
        private Guid _id;
        private string _name;
        private TypeCinema _type;
        private int _numberSequel;
        private StatusCinema _status;
        private DateTime? _date;
        private int? _grade;

        public CinemaModel(string name, decimal? numberSequel, StatusCinema status, TypeCinema type)
            : this(name, numberSequel, null, null, status, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, StatusCinema status, TypeCinema type, Guid? id)
            : this(name, numberSequel, null, null, status, type, id)
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, StatusCinema status, TypeCinema type)
            : this(name, numberSequel, date, grade, status, type, Guid.NewGuid())
        {
        }

        public CinemaModel(string name, decimal? numberSequel, DateTime? date, decimal? grade, StatusCinema status, TypeCinema type, Guid? id)
        {
            _id = id ?? Guid.NewGuid();
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _numberSequel = numberSequel == null ? 0 : Convert.ToInt32((decimal)numberSequel);
            _type = type;
            _status = status;
            _date = date;
            _grade = grade == null ? null : Convert.ToInt32((decimal)grade);
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

        public TypeCinema Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public StatusCinema Status
        {
            get => _status;
            set => SetField(ref _status, value);
        }

        public int NumberSequel
        {
            get => _numberSequel;
            set => SetField(ref _numberSequel, value);
        }

        public DateTime? Date
        {
            get => _date;
            set => SetField(ref _date, value);
        }

        public int? Grade
        {
            get => _grade;
            set => SetField(ref _grade, value);
        }

        public WatchItem ToWatchItem()
        {
            return new WatchItem(Name, NumberSequel, Status, Type, Id, Date ?? null, Grade);
        }

        public string GetWatchData() => Date?.ToString("dd.MM.yyyy") ?? string.Empty;

        public bool HasWatchDate() => Date != null;
    }
}
