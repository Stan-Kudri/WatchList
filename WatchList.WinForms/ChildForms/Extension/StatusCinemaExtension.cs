using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.ChildForms.Extension
{
    public static class StatusCinemaExtension
    {
        public static bool HasDateWatch(this StatusCinema status) => status == StatusCinema.Viewed;

        public static bool HasGradeCinema(this StatusCinema status) => status != StatusCinema.Planned;
    }
}
