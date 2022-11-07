using Ardalis.SmartEnum;

namespace ListWatchedMoviesAndSeries.Models.Item
{
    public sealed class TypeCinema : SmartEnum<TypeCinema>
    {
        private readonly string _typeSequel = string.Empty;

        public static readonly TypeCinema Unknown = new TypeCinema("Cinema", 0, "Sequel");
        public static readonly TypeCinema Movie = new TypeCinema("Movie", 1, "Part");
        public static readonly TypeCinema Series = new TypeCinema("Series", 2, "Season");
        public static readonly TypeCinema Anime = new TypeCinema("Anime", 3, "Season");
        public static readonly TypeCinema Cartoon = new TypeCinema("Cartoon", 4, "Part");

        public string TypeSequel => _typeSequel;

        private TypeCinema(string category, int value, string typeSequel) : base(category, value)
        {
            _typeSequel = typeSequel;
        }
    }
}
