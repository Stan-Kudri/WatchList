using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.ASP.Net.Controllers.Model
{
    public class WatchItemModel
    {
        public WatchItemModel(string title, int sequel, Status status, Types type, string? id, DateTime? dateWatch = null, int? grade = null)
        {
            Title = title ?? throw new ArgumentException("Invalid title format.", nameof(title));
            Sequel = sequel > 0 ? sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(sequel));
            TypeCinema = GetEnumTypeCinema(type);
            StatusCinema = GetEnumStatus(status);
            Date = dateWatch;
            Grade = grade;
            Id = Guid.TryParse(id, out var resultId) ? resultId : Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public TypeCinema TypeCinema { get; set; }

        public StatusCinema StatusCinema { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; }

        public int? Grade { get; set; }

        private StatusCinema GetEnumStatus(Status status)
        {
            return status switch
            {
                Status.AllStatus => StatusCinema.AllStatus,
                Status.Viewed => StatusCinema.Viewed,
                Status.Planned => StatusCinema.Planned,
                Status.Look => StatusCinema.Look,
                Status.Thrown => StatusCinema.Thrown,
                _ => StatusCinema.AllStatus,
            };
        }

        private TypeCinema GetEnumTypeCinema(Types type)
        {
            return type switch
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
}
