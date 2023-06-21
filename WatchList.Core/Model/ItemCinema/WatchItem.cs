using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.ItemCinema
{
    public class WatchItem : IEquatable<WatchItem>
    {
        private const string FormatDate = "dd.MM.yyyy";

        public WatchItem(string title, int sequel, StatusCinema status, TypeCinema type, Guid? id, DateTime? dateWatch = null, int? grade = null)
        {
            Title = title ?? throw new ArgumentException("Invalid title format.", nameof(title));
            Sequel = sequel > 0 ? sequel : throw new ArgumentException("The sequel number is greater than zero.", nameof(sequel));
            Type = type;
            Status = status;
            Date = dateWatch;
            Grade = grade;
            Id = id ?? Guid.NewGuid();
        }

        // EF core
        private WatchItem()
            : this(string.Empty, 1, StatusCinema.AllStatus, TypeCinema.AllType, null, null, 0)
        {
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public TypeCinema Type { get; set; }

        public StatusCinema Status { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; }

        public int? Grade { get; set; }

        public override int GetHashCode() => HashCode.Combine(Id, Title, Grade, Date, Status, Type, Sequel);

        public override bool Equals(object? obj) => Equals(obj as WatchItem);

        public bool Equals(WatchItem? other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id
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
