using Ardalis.SmartEnum;

namespace Core.Model.Item
{
    public class SortField : SmartEnum<SortField>
    {
        public static readonly SortField Title = new SortField("Title", 0);
        public static readonly SortField Sequel = new SortField("Sequel", 1);
        public static readonly SortField Status = new SortField("Status", 2);
        public static readonly SortField Data = new SortField("Data", 3);
        public static readonly SortField Grade = new SortField("Grade", 4);
        public static readonly SortField Type = new SortField("Type", 5);

        private SortField(string name, int value) : base(name, value)
        {
        }
    }
}
