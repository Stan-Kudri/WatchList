using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Core.Model.ItemCinema.Components;

namespace Core.Model.ItemCinema
{
    public class WatchItem : IEquatable<WatchItem>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public TypeCinema Type { get; set; }

        public StatusCinema Status { get; set; }

        public int Sequel { get; set; }

        public DateTime? Date { get; set; }

        public int? Grade { get; set; }

        // EF core
        private WatchItem() : this(string.Empty, 0, StatusCinema.AllStatus, TypeCinema.AllType, null, null, 0)
        {
        }

        public WatchItem(string title, int numberSequel, StatusCinema status, TypeCinema type, Guid? id, DateTime? dateWatch, int? grade)
        {
            Id = id ?? Guid.NewGuid();
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Sequel = numberSequel;
            Type = type;
            Status = status;
            Date = dateWatch;
            Grade = grade == null ? null : grade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Grade, Date, Status, Type, Sequel);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as WatchItem);
        }

        public bool Equals(WatchItem? other)
        {
            if (other == null)
                return false;

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
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            });
        }

        public string GetWatchData() => Date?.ToString("dd.MM.yyyy") ?? string.Empty;

        public bool HasWatchDate() => Date != null;
    }
}
