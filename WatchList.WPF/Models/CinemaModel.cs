using DevExpress.Mvvm;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WPF.Models
{
    public class CinemaModel : BindableBase
    {
        private Guid _id;
        private string _title;
        private TypeCinema _type;
        private int _sequel;
        private StatusCinema _status;
        private DateTime? _date;
        private int? _grade;

        public CinemaModel()
            : this(string.Empty, null, null, null, StatusCinema.Planned, TypeCinema.Movie)
        {
        }

        public CinemaModel(string title, decimal? sequel, DateTime? date, decimal? grade, StatusCinema status, TypeCinema type, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Sequel = sequel == null ? 0 : Convert.ToInt32((decimal)sequel);
            Type = type;
            Status = status;
            Date = date;
            Grade = grade != null ? Convert.ToInt32((decimal)grade) : null;
        }

        public Guid Id
        {
            get => _id;
            set => SetValue(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetValue(ref _title, value);
        }

        public TypeCinema Type
        {
            get => _type;
            set => SetValue(ref _type, value);
        }

        public StatusCinema Status
        {
            get => _status;
            set => SetValue(ref _status, value);
        }

        public int Sequel
        {
            get => _sequel;
            set => SetValue(ref _sequel, value);
        }

        public DateTime? Date
        {
            get => _date;
            set => SetValue(ref _date, value);
        }

        public int? Grade
        {
            get => _grade;
            set => SetValue(ref _grade, value, nameof(Grade));
        }

        public static CinemaModel GetCinemaFromWatchItem(WatchItem? item)
            => item != null
                ? new CinemaModel(item.Title, item.Sequel, item.Date, item.Grade, item.Status, item.Type, item.Id)
                : new CinemaModel();

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
