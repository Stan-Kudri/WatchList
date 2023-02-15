using Ardalis.SmartEnum;
using Core.Model.ItemCinema.Components;

namespace Core.Model.Filter.Components
{
    public sealed class StatusFilter : SmartEnum<StatusFilter>
    {
        private readonly StatusCinema _status;

        public StatusCinema Status => _status;

        public static readonly StatusFilter AllCinema = new StatusFilter("All", 0, StatusCinema.AllStatus);
        public static readonly StatusFilter ViewedCinema = new StatusFilter("Viewed Cinema", 1, StatusCinema.Viewed);
        public static readonly StatusFilter PlannedWatchCinema = new StatusFilter("Planned Watch Cinema", 2, StatusCinema.Planned);
        public static readonly StatusFilter LookCinema = new StatusFilter("Look Cinema", 3, StatusCinema.Look);
        public static readonly StatusFilter ThrownCinema = new StatusFilter("Thrown Watch Cinema", 4, StatusCinema.Thrown);

        private StatusFilter(string name, int value, StatusCinema status) : base(name, value)
        {
            _status = status;
        }
    }
}
