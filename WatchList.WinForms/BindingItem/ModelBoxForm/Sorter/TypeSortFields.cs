using Ardalis.SmartEnum;

namespace TestTask.BindingItem.Pages
{
    public class TypeSortFields : SmartEnum<TypeSortFields>
    {
        public static TypeSortFields Unknown = new TypeSortFields("Unknown", 0);
        public static TypeSortFields Ascending = new TypeSortFields("↑", 1);
        public static TypeSortFields Descending = new TypeSortFields("↓", 2);

        public TypeSortFields(string name, int value)
            : base(name, value)
        {
        }
    }
}
