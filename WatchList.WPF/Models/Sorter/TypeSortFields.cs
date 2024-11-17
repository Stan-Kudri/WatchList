using Ardalis.SmartEnum;

namespace WatchList.WPF.Models.Sorter
{
    public class TypeSortFields : SmartEnum<TypeSortFields>
    {
        public static readonly TypeSortFields Unknown = new TypeSortFields("Unknown", 0);
        public static readonly TypeSortFields Ascending = new TypeSortFields("↑", 1);
        public static readonly TypeSortFields Descending = new TypeSortFields("↓", 2);

        public TypeSortFields(string name, int value)
            : base(name, value)
        {
        }
    }
}
