using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Load
{
    public class BaseLoadRulesConfigModel : ILoadRulesConfig
    {
        public BaseLoadRulesConfigModel()
            : this(false, new ActionDuplicateItems(), null, Grade.AnyGrade)
        {
        }

        public BaseLoadRulesConfigModel(bool deleteGrade, ActionDuplicateItems actionsWithDuplicates, TypeCinema? typeCinema, Grade moreGrade)
        {
            DeleteGrade = deleteGrade;
            ActionsWithDuplicates = actionsWithDuplicates;
            TypeCinemaLoad = typeCinema;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; } = false;

        public ActionDuplicateItems ActionsWithDuplicates { get; private set; } = new ActionDuplicateItems();

        public TypeCinema? TypeCinemaLoad { get; private set; } = null;

        public Grade MoreGrade { get; private set; } = Grade.AnyGrade;
    }
}
