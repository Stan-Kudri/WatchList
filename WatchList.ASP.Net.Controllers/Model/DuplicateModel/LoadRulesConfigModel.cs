using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.ASP.Net.Controllers.Model.DuplicateModel
{
    public class LoadRulesConfigModel : ILoadRulesConfig
    {
        public LoadRulesConfigModel()
            : this(false, new ActionDuplicateItems(), TypeCinema.AllType, Grade.AnyGrade)
        {
        }

        public LoadRulesConfigModel(bool deleteGrade, ActionDuplicateItems actionsWithDuplicates, TypeCinema typeCinema, Grade moreGrade)
        {
            DeleteGrade = deleteGrade;
            ActionsWithDuplicates = actionsWithDuplicates;
            TypeCinemaLoad = typeCinema;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; } = false;

        public ActionDuplicateItems ActionsWithDuplicates { get; private set; } = new ActionDuplicateItems();

        public TypeCinema TypeCinemaLoad { get; private set; } = TypeCinema.AllType;

        public Grade MoreGrade { get; private set; } = Grade.AnyGrade;
    }
}
