using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.ItemCinema
{
    public class WatchItem : IEquatable<WatchItem>
    {
        protected const string FormatDate = "dd.MM.yyyy";

        public WatchItem(string title, int sequel, StatusCinema status, TypeCinema type, Guid? id = null, DateTime? dateWatch = null, int? grade = null)
        {
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentException("Invalid title format.", nameof(title)) : title;
            Sequel = sequel > 0 ? sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(sequel));
            Type = type;
            Status = status;
            Date = dateWatch;
            Grade = grade;
            Id = id ?? Guid.NewGuid();
        }

        // EF core
        protected WatchItem()
        {
            Title = string.Empty;
            Sequel = 1;
            Type = TypeCinema.Movie;
            Status = StatusCinema.Planned;
            Date = null;
            Grade = null;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public TypeCinema Type { get; set; }

        public StatusCinema Status { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; }

        public int? Grade { get; set; }

        public string TitleNormalized { get; set; } = string.Empty;

        public override int GetHashCode() => HashCode.Combine(Id, Title, Grade, Date, Status, Type, Sequel);

        public override bool Equals(object? obj) => Equals(obj as WatchItem);

        public bool Equals(WatchItem? other)
        {
            return other == null
                   ? false
                   : Id == other.Id
                     && Title == other.Title
                     && Status == other.Status
                     && Type == other.Type
                     && Sequel == other.Sequel
                     && Grade == other.Grade
                     && Date == other.Date;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            });
        }

        public string GetWatchData() => Date?.ToString(FormatDate) ?? string.Empty;
    }
}
