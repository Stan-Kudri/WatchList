using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Core.Model.Item;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public class WatchItem : IEquatable<WatchItem>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TypeCinema Type { get; set; }

        public StatusCinema Status { get; set; }

        [Required]
        [Column(TypeName = "INTEGER")]
        public int NumberSequel { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "INTEGER")]
        public int? Grade { get; set; }

        // EF core
        private WatchItem() : this(string.Empty, 0, StatusCinema.AllStatus, TypeCinema.AllType, null, null, 0)
        {
        }

        public WatchItem(string name, int numberSequel, StatusCinema status, TypeCinema type, Guid? id, DateTime? dateWatch, int? grade)
        {
            Id = id ?? Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            NumberSequel = numberSequel;
            Type = type;
            Status = status;
            Date = dateWatch;
            Grade = grade == null ? null : grade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Grade, Date, Status, Type, NumberSequel);
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
                && Name == other.Name
                && Status == other.Status
                && Type == other.Type
                && NumberSequel == other.NumberSequel
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
