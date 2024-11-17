using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WPF.Models
{
    public class CinemaModel : BindingBaseModel
    {
        private Guid _id;
        private string _title;
        private TypeCinema _type;
        private int _sequel;
        private StatusCinema _status;
        private DateTime? _date;
        private int? _grade;

        private CinemaModel(string title, decimal? sequel, DateTime? date, decimal? grade, StatusCinema status, TypeCinema type, Guid? id = null)
        {
            _id = id ?? Guid.NewGuid();
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _sequel = sequel == null ? 0 : Convert.ToInt32((decimal)sequel);
            _type = type;
            _status = status;
            _date = date;
            _grade = grade != null ? Convert.ToInt32((decimal)grade) : null;
        }

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public TypeCinema Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public StatusCinema Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public int Sequel
        {
            get => _sequel;
            set
            {
                _sequel = value;
                OnPropertyChanged("Sequel");
            }
        }

        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public int? Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                OnPropertyChanged("Grade");
            }
        }

        public static CinemaModel CreateNonPlanned(
            string title,
            decimal? sequel,
            DateTime? date,
            decimal? grade,
            StatusCinema status,
            TypeCinema type,
            Guid? id = null)
            => new CinemaModel(title, sequel, date, grade, status, type, id);

        public static CinemaModel CreatePlanned(string title, decimal? sequel, StatusCinema status, TypeCinema type, Guid? id)
            => new CinemaModel(title, sequel, null, null, status, type, id);

        public WatchItem ToWatchItem()
            => new WatchItem(Title, Sequel, Status, Type, Id, Date ?? null, Grade);

        public bool TryGetWatchDate(out DateTime date)
        {
            if (_status == StatusCinema.Viewed && Date != null)
            {
                date = Date.Value;
                return true;
            }

            date = default;
            return false;
        }

        public bool HasGrade() => _status != StatusCinema.Planned;
    }
}
