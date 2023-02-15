using Ardalis.SmartEnum;

namespace Core.Model.Item
{
    public class TypesSort : SmartEnum<TypesSort>
    {
        public static readonly TypesSort Title = new TypesSort("Title", 0);
        public static readonly TypesSort Sequel = new TypesSort("Sequel", 1);
        public static readonly TypesSort Status = new TypesSort("Status", 2);
        public static readonly TypesSort Data = new TypesSort("Data", 3);
        public static readonly TypesSort Grade = new TypesSort("Grade", 4);
        public static readonly TypesSort Type = new TypesSort("Type", 5);

        private TypesSort(string name, int value) : base(name, value)
        {
        }
    }
}
