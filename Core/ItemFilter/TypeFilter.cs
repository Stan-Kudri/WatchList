using Ardalis.SmartEnum;
using ListWatchedMoviesAndSeries.Models.Item;

namespace Core.ItemFilter
{
    public sealed class TypeFilter : SmartEnum<TypeFilter>
    {
        private readonly TypeCinema _typeCinema = TypeCinema.AllType;

        public TypeCinema Type => _typeCinema;

        public static readonly TypeFilter AllCinema = new TypeFilter("All Cinema", 0, TypeCinema.AllType);
        public static readonly TypeFilter Movie = new TypeFilter("Movie", 1, TypeCinema.Movie);
        public static readonly TypeFilter Series = new TypeFilter("Series", 2, TypeCinema.Series);
        public static readonly TypeFilter Anime = new TypeFilter("Anime", 3, TypeCinema.Anime);
        public static readonly TypeFilter Cartoon = new TypeFilter("Cartoon", 4, TypeCinema.Cartoon);

        private TypeFilter(string name, int value, TypeCinema typeCinema) : base(name, value)
        {
            _typeCinema = typeCinema;
        }
    }
}
