using WatchList.Core.Enums;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.ASP.Net.Controllers.Model
{
    public class WatchItemModel
    {
        public string? Title { get; set; }

        public Types Type { get; set; }

        public Status Status { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; } = null;

        public int? Grade { get; set; } = null;

        public WatchItem GetWatchItem(Guid? oldId = null)
        {
            var title = Title ?? throw new ArgumentException("Invalid title format.", nameof(Title));
            var sequel = Sequel > 0 ? Sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(Sequel));
            var typeCinema = TypeCinema.FromValue(Type);
            var statusCinema = StatusCinema.FromValue(Status);

            if (statusCinema == StatusCinema.Viewed)
            {
                return new WatchItem(title, sequel, statusCinema, typeCinema, oldId, Date ?? DateTime.UtcNow, Grade ?? 5);
            }
            else if (statusCinema == StatusCinema.Look || statusCinema == StatusCinema.Planned)
            {
                return new WatchItem(title, sequel, statusCinema, typeCinema, oldId, null, null);
            }

            return new WatchItem(title, sequel, statusCinema, typeCinema, oldId, Date, Grade);
        }
    }
}
