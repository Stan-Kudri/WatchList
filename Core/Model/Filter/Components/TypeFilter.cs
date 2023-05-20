using Ardalis.SmartEnum;
using Core.Model.ItemCinema.Components;

namespace Core.Model.Filter.Components
{
    public sealed class TypeFilter : SmartEnum<TypeFilter>
    {
        public static readonly TypeFilter AllCinema = new TypeFilter("All Cinema", 0, TypeCinema.AllType);
        public static readonly TypeFilter Movie = new TypeFilter("Movie", 1, TypeCinema.Movie);
        public static readonly TypeFilter Series = new TypeFilter("Series", 2, TypeCinema.Series);
        public static readonly TypeFilter Anime = new TypeFilter("Anime", 3, TypeCinema.Anime);
        public static readonly TypeFilter Cartoon = new TypeFilter("Cartoon", 4, TypeCinema.Cartoon);

        private readonly TypeCinema _typeCinema = TypeCinema.AllType;

        private TypeFilter(string name, int value, TypeCinema typeCinema)
            : base(name, value)
        {
            _typeCinema = typeCinema;
        }

        public TypeCinema Type => _typeCinema;
    }
}
