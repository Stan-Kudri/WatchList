using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load.Components
{
    public class TypeLoadingCinema : Wrapper<TypeCinema?>
    {
        public TypeLoadingCinema(TypeCinema? value = null)
            => Value = value;

        public static ObservableCollection<TypeLoadingCinema> Items => new ObservableCollection<TypeLoadingCinema>()
        {
            new TypeLoadingCinema(null),
            new TypeLoadingCinema(TypeCinema.Movie),
            new TypeLoadingCinema(TypeCinema.Cartoon),
            new TypeLoadingCinema(TypeCinema.Anime),
            new TypeLoadingCinema(TypeCinema.Series),
        };

        public override string Name => Value != null ? Value.Name : "All Type";

        public override string ToString() => Name;
    }
}
