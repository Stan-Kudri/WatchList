using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load.Components
{
    public class TypeCinemaModel : SmartEnumBaseWrapper<TypeCinema?>, IEquatable<TypeCinemaModel>
    {
        public TypeCinemaModel(TypeCinema? value = null) => Value = value;

        public static ObservableCollection<TypeCinemaModel> GetItemsType => GetItems(TypeCinema.List, e => new TypeCinemaModel(e));

        public static TypeCinemaModel AllType
            => new TypeCinemaModel(null);

        public override string Name
            => Value != null ? Value.Name : "All Type";

        public bool Equals(TypeCinemaModel? other)
            => other is not null
                && Value == other.Value
                && Name == other.Name;

        public override bool Equals(object? obj)
            => Equals(obj as TypeCinemaModel);

        public override int GetHashCode()
            => HashCode.Combine(Name, Value);

        public override string ToString() => Name;
    }
}
