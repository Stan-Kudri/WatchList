using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load.Components
{
    public class TypeLoadingCinema : SmartEnumBaseWrapper<TypeCinema?>, IEquatable<TypeLoadingCinema>
    {
        public static ObservableCollection<TypeLoadingCinema> GetItemsType = GetItems(TypeCinema.List, e => new TypeLoadingCinema(e));

        public TypeLoadingCinema(TypeCinema? value = null)
            => Value = value;

        public static TypeLoadingCinema AllType
            => new TypeLoadingCinema(null);

        public override string Name
            => Value != null ? Value.Name : "All Type";

        public bool Equals(TypeLoadingCinema? other)
        {
            return ReferenceEquals(other, null)
                    ? false
                    : Value == other.Value && Name == other.Name;
        }

        public override bool Equals(object? obj)
            => Equals(obj as TypeLoadingCinema);

        public override int GetHashCode()
            => HashCode.Combine(Name, Value);

        public override string ToString() => Name;
    }
}
