using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace Core.Model.ItemCinema.Components
{
    public class TypeCinema : SmartEnum<TypeCinema>
    {
        private readonly string _typeSequel = string.Empty;

        public static readonly TypeCinema AllType = new TypeCinema("Unknown", 0, "Unknown");
        public static readonly TypeCinema Movie = new TypeCinema("Movie", 1, "Part");
        public static readonly TypeCinema Series = new TypeCinema("Series", 2, "Season");
        public static readonly TypeCinema Anime = new TypeCinema("Anime", 3, "Season");
        public static readonly TypeCinema Cartoon = new TypeCinema("Cartoon", 4, "Part");

        [JsonPropertyName("TypeSequel")]
        public string TypeSequel => _typeSequel;

        private TypeCinema(string category, int value, string typeSequel) : base(category, value)
        {
            _typeSequel = typeSequel;
        }
    }
}
