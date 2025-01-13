using Microsoft.AspNetCore.Components;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.MudBlazors.Model
{
    public class WatchItemModel
    {
        private const int FirstValue = 1;

        public WatchItemModel()
        {
        }

        public WatchItemModel(string title, int sequel, DateTime? date, int? grade, StatusCinema? status, TypeCinema? type, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Sequel = sequel;
            Type = type;
            Status = status;
            Date = date;
            Grade = grade;
        }

        [Parameter]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Parameter]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public TypeCinema? Type { get; set; } = TypeCinema.Movie;

        [Parameter]
        public StatusCinema? Status { get; set; } = StatusCinema.Planned;

        [Parameter]
        public int Sequel { get; set; } = FirstValue;

        [Parameter]
        public DateTime? Date { get; set; } = null;

        [Parameter]
        public int? Grade { get; set; } = null;

        public WatchItem ToWatchItem() => new WatchItem(Title, Sequel, Status, Type, Id, Date ?? null, Grade);

        public void ClearData()
        {
            Title = string.Empty;
            Id = new Guid();
            Type = TypeCinema.Movie;
            Sequel = FirstValue;
            Status = StatusCinema.Planned;
            Date = null;
            Grade = FirstValue;
        }
    }
}
