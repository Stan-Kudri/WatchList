using Ardalis.SmartEnum;
using WatchList.Core.Enums;

namespace WatchList.Core.Model.ItemCinema.Components
{
    public class StatusCinema : SmartEnum<StatusCinema>
    {
        public static readonly StatusCinema AllStatus = new StatusCinema("Unknown", Status.AllStatus);
        public static readonly StatusCinema Viewed = new StatusCinema("Viewed", Status.Viewed);
        public static readonly StatusCinema Planned = new StatusCinema("Planned Watch", Status.Planned);
        public static readonly StatusCinema Look = new StatusCinema("Look", Status.Look);
        public static readonly StatusCinema Thrown = new StatusCinema("Thrown Watch", Status.Thrown);

        private StatusCinema(string name, Status status)
            : base(name, (int)status)
        {
        }
    }
}
