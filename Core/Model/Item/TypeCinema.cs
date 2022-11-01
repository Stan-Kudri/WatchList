using Ardalis.SmartEnum;

namespace ListWatchedMoviesAndSeries.Models.Item
{
    public sealed class TypeCinema : SmartEnum<TypeCinema>
    {
        public static readonly TypeCinema Unknown = new TypeCinema("Sequel", 0);
        public static readonly TypeCinema Movie = new TypeCinema("Part Movie", 1);
        public static readonly TypeCinema Series = new TypeCinema("Season Series", 2);
        public static readonly TypeCinema Anime = new TypeCinema("Season Anime", 3);
        public static readonly TypeCinema Cartoon = new TypeCinema("Part Cartoon", 4);

        private TypeCinema(string category, int value) : base(category, value)
        {
        }
    }
}
