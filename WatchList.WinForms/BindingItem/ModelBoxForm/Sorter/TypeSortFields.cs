using Ardalis.SmartEnum;

namespace TestTask.BindingItem.Pages
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
