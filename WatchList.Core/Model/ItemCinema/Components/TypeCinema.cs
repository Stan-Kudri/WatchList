using System.Text.Json.Serialization;
using Ardalis.SmartEnum;
using WatchList.Core.Enums;

namespace WatchList.Core.Model.ItemCinema.Components
{
    public class TypeCinema : SmartEnum<TypeCinema>
    {
        public static readonly TypeCinema Movie = new TypeCinema("Movie", Types.Movie, "Part");
        public static readonly TypeCinema Series = new TypeCinema("Series", Types.Series, "Season");
        public static readonly TypeCinema Anime = new TypeCinema("Anime", Types.Anime, "Season");
        public static readonly TypeCinema Cartoon = new TypeCinema("Cartoon", Types.Cartoon, "Part");

        private TypeCinema(string category, Types types, string typeSequel)
            : base(category, (int)types) => TypeSequel = typeSequel;

        [JsonPropertyName("TypeSequel")]
        public string TypeSequel { get; }

        public static TypeCinema FromValue(Types types) => FromValue((int)types);
    }
}
