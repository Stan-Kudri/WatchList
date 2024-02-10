using Microsoft.AspNetCore.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.MudBlazors.Model
{
    public class WatchItemModel
    {
        private const int FirstValue = 1;

        private Guid _id = new Guid();
        private string _title = string.Empty;
        private TypeCinema _type = TypeCinema.Movie;
        private int _sequel = FirstValue;
        private StatusCinema _status = StatusCinema.Planned;
        private DateTime? _date = null;
        private int? _grade = FirstValue;

        public WatchItemModel()
        {
        }

        public WatchItemModel(string title, int sequel, DateTime? date, int? grade, StatusCinema status, TypeCinema type, Guid? id = null)
        {
            _id = id ?? Guid.NewGuid();
            _title = title ?? throw new ArgumentNullException(nameof(title));
            _sequel = sequel;
            _type = type;
            _status = status;
            _date = date;
            _grade = grade;
        }

        [Parameter]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        [Parameter]
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        [Parameter]
        public TypeCinema Type
        {
            get => _type;
            set => _type = value;
        }

        [Parameter]
        public StatusCinema Status
        {
            get => _status;
            set => _status = value;
        }

        [Parameter]
        public int Sequel
        {
            get => _sequel;
            set => _sequel = value;
        }

        [Parameter]
        public DateTime? Date
        {
            get => _date;
            set => _date = value;
        }

        [Parameter]
        public int? Grade
        {
            get => _grade;
            set => _grade = value;
        }

        public static WatchItemModel CreateNonPlanned(
            string title,
            int sequel,
            DateTime? date,
            int? grade,
            StatusCinema status,
            TypeCinema type,
            Guid? id = null)
            => new WatchItemModel(title, sequel, date, grade, status, type, id);

        public static WatchItemModel CreatePlanned(string title, int sequel, StatusCinema status, TypeCinema type, Guid? id)
            => new WatchItemModel(title, sequel, null, null, status, type, id);

        public WatchItem ToWatchItem() => new WatchItem(Title, Sequel, Status, Type, Id, Date ?? null, Grade);

        public void ClearData()
        {
            _title = string.Empty;
            _id = new Guid();
            _type = TypeCinema.Movie;
            _sequel = FirstValue;
            _status = StatusCinema.Planned;
            _date = null;
            _grade = FirstValue;
        }

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
