using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.Test.Components
{
    public class TestLoadRuleConfig : ILoadRulesConfig
    {
        public TestLoadRuleConfig()
        {
        }

        public TestLoadRuleConfig(bool deleteGrade, TypeCinema? typeCinema, Grade grade, ActionDuplicateItems actionDuplicateItems)
        {
            DeleteGrade = deleteGrade;
            TypeCinemaLoad = typeCinema;
            MoreGrade = grade;
            ActionsWithDuplicates = actionDuplicateItems;
        }

        public bool DeleteGrade { get; set; } = false;

        public TypeCinema? TypeCinemaLoad { get; set; } = null;

        public Grade MoreGrade { get; set; } = Grade.AnyGrade;

        public ActionDuplicateItems ActionsWithDuplicates { get; set; } = new ActionDuplicateItems();
    }
}
