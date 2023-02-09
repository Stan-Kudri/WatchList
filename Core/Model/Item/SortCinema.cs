using Ardalis.SmartEnum;

namespace Core.Model.Item
{
    public class SortCinema : SmartEnum<SortCinema>
    {
        public static readonly SortCinema Title = new SortCinema("Title", 0);
        public static readonly SortCinema Sequel = new SortCinema("Sequel", 1);
        public static readonly SortCinema Status = new SortCinema("Status", 2);
        public static readonly SortCinema Data = new SortCinema("Data", 3);
        public static readonly SortCinema Grade = new SortCinema("Grade", 4);
        public static readonly SortCinema Type = new SortCinema("Type", 5);

        private SortCinema(string name, int value) : base(name, value)
        {
        }
    }
}
