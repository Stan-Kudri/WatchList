using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.ASP.Net.Controllers.Model
{
    public class WatchItemModel
    {
        public string? Id { get; set; }

        public string? Title { get; set; }

        public Types Type { get; set; }

        public Status Status { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; } = null;

        public int? Grade { get; set; } = null;

        public WatchItem GetWatchItem()
        {
            if (Status == Status.AllStatus)
            {
                throw new ArgumentException("This status is not possible for the item.", nameof(Status));
            }

            var title = Title ?? throw new ArgumentException("Invalid title format.", nameof(Title));
            var sequel = Sequel > 0 ? Sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(Sequel));
            var id = !Guid.TryParse(Id, out var resultId) ? resultId : Guid.NewGuid();
            var typeCinema = GetEnumTypeCinema;
            var statusCinema = GetEnumStatus;

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

        private StatusCinema GetEnumStatus => Status switch
        {
            Status.AllStatus => StatusCinema.AllStatus,
            Status.Viewed => StatusCinema.Viewed,
            Status.Planned => StatusCinema.Planned,
            Status.Look => StatusCinema.Look,
            Status.Thrown => StatusCinema.Thrown,
            _ => StatusCinema.AllStatus,
        };

        private TypeCinema GetEnumTypeCinema => Type switch
        {
            Types.AllType => TypeCinema.AllType,
            Types.Movie => TypeCinema.Movie,
            Types.Series => TypeCinema.Series,
            Types.Anime => TypeCinema.Anime,
            Types.Cartoon => TypeCinema.Cartoon,
            _ => TypeCinema.AllType,
        };
    }
}
