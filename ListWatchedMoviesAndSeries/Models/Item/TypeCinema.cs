using Ardalis.SmartEnum;

namespace ListWatchedMoviesAndSeries.Models.Item
{
    public sealed class TypeCinema : SmartEnum<TypeCinema>
    {
        public static readonly TypeCinema Unknown = new TypeCinema("Sequel", 0);
        public static readonly TypeCinema Movie = new TypeCinema("Part", 1);
        public static readonly TypeCinema Series = new TypeCinema("Season", 2);

        private TypeCinema(string category, int value) : base(category, value)
        {
        }
    }
}
