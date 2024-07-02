using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load.Components
{
    public class TypeLoadingCinema : SmartEnumBaseWrapper<TypeCinema?>
    {
        public TypeLoadingCinema(TypeCinema? value = null)
            => Value = value;

        public static ObservableCollection<TypeLoadingCinema> Items = GetItems(TypeCinema.List, e => new TypeLoadingCinema(e));

        public override string Name => Value != null ? Value.Name : "All Type";

        public override string ToString() => Name;
    }
}
