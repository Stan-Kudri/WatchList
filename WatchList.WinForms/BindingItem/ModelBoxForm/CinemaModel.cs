using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelBoxForm
{
    public class CinemaModel : ModelBase
    {
        private const string FormatDate = "dd.MM.yyyy";

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
            set => SetField(ref _id, value);
        }

        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
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

        public int Sequel
        {
            get => _sequel;
            set => SetField(ref _sequel, value);
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

        public WatchItem ToWatchItem() => new WatchItem(Title, Sequel, Status, Type, Id, Date ?? null, Grade);

        public string GetWatchData() => Date?.ToString(FormatDate) ?? string.Empty;

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

        public bool HasGrade() => _status != StatusCinema.Planned && _status != StatusCinema.AllStatus;
    }
}
