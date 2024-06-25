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

        public WatchItem GetWatchItem(string? oldId = null)
        {
            if (Status == Status.AllStatus)
            {
                throw new ArgumentException("This status is not possible for the item.", nameof(Status));
            }

            var title = Title ?? throw new ArgumentException("Invalid title format.", nameof(Title));
            var sequel = Sequel > 0 ? Sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(Sequel));
            var id = Guid.TryParse(oldId, out var itemId) ? itemId : Guid.NewGuid();
            var typeCinema = TypeCinema.FromValue((int)Type);
            var statusCinema = StatusCinema.FromValue((int)Status);

            if (statusCinema == StatusCinema.Viewed)
            {
                return new WatchItem(title, sequel, statusCinema, typeCinema, id, Date ?? DateTime.UtcNow, Grade ?? 5);
            }
            else if (statusCinema == StatusCinema.Look || statusCinema == StatusCinema.Planned)
            {
                return new WatchItem(title, sequel, statusCinema, typeCinema, id, null, null);
            }

            return new WatchItem(title, sequel, statusCinema, typeCinema, id, Date, Grade);
        }
    }
}
