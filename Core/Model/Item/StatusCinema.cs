using Ardalis.SmartEnum;

namespace Core.Model.Item
{
    public class StatusCinema : SmartEnum<StatusCinema>
    {
        public static readonly StatusCinema AllStatus = new StatusCinema("Unknown", 0);
        public static readonly StatusCinema Viewed = new StatusCinema("Viewed", 1);
        public static readonly StatusCinema Planned = new StatusCinema("Planned Watch", 2);
        public static readonly StatusCinema Look = new StatusCinema("Look", 3);
        public static readonly StatusCinema Thrown = new StatusCinema("Thrown Watch", 4);

        private StatusCinema(string name, int value) : base(name, value)
        {
        }
    }
}
