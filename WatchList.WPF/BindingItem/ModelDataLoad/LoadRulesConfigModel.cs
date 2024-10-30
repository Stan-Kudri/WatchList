using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.WPF.BindingItem.ModelDataLoad
{
    public class LoadRulesConfigModel : ILoadRulesConfig
    {
        public LoadRulesConfigModel()
            : this(false, new ActionDuplicateItems(), null, Grade.AnyGrade)
        {
        }

        public LoadRulesConfigModel(bool deleteGrade, ActionDuplicateItems actionsWithDuplicates, TypeCinema? typeCinema, Grade moreGrade)
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
