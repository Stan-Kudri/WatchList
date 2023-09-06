using WatchList.Core.Repository;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.Test.Components
{
    public class TestAggregateLoadRule : AggregateLoadRule
    {
        public TestAggregateLoadRule(WatchItemRepository itemRepository, TestLoadRuleConfig loadRulesConfig)
            : base(new ILoadRule[]
            {
                new DeleteGradeRule(loadRulesConfig),
                new FilterByTypeCinemaLoadRule(loadRulesConfig),
                new FilterByMoreGradeLoadRule(loadRulesConfig),
                new DuplicateLoadRule(itemRepository, loadRulesConfig),
            })
        {
        }
    }
}
