using WatchList.Core.Model.Load;
using WatchList.Core.Repository;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.Core.Extension
{
    public static class LoadRulesExtension
    {
        public static AggregateLoadRule GetAggregateRules(this ILoadRulesConfig loadRulesConfig, WatchItemRepository watchItemRepository)
        {
            var loadRuleHasGrade = new DeleteGradeRule(loadRulesConfig);
            var loadRuleType = new FilterByTypeCinemaLoadRule(loadRulesConfig);
            var loadRuleMoreGrade = new FilterByMoreGradeLoadRule(loadRulesConfig);
            var loadDuplicateItem = new DuplicateLoadRule(watchItemRepository, loadRulesConfig);

            return new AggregateLoadRule { loadRuleHasGrade, loadRuleType, loadRuleMoreGrade, loadDuplicateItem };
        }
    }
}
