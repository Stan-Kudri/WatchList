using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load
{
    public interface ILoadRulesConfig
    {
        bool DeleteGrade { get; }

        ActionDuplicateItems ActionsWithDuplicates { get; }

        TypeCinema TypeCinemaLoad { get; }

        Grade MoreGrade { get; }
    }
}
