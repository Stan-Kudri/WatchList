using WatchList.ASP.Net.Controllers.Model.DuplicateModel;
using WatchList.Core.Repository;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.ASP.Net.Controllers.Extension
{
    public static class LoadRulesExtension
    {
        public static AggregateLoadRule GetAggregateRules(this LoadRulesConfigModel loadRulesConfig, WatchItemRepository watchItemRepository)
        {
            var loadRuleHasGrade = new DeleteGradeRule(loadRulesConfig);
            var loadRuleType = new FilterByTypeCinemaLoadRule(loadRulesConfig);
            var loadRuleMoreGrade = new FilterByMoreGradeLoadRule(loadRulesConfig);
            var loadDuplicateItem = new DuplicateLoadRule(watchItemRepository, loadRulesConfig);

            return new AggregateLoadRule { loadRuleHasGrade, loadRuleType, loadRuleMoreGrade, loadDuplicateItem };
        }
    }
}
