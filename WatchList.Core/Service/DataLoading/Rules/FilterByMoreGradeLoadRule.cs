using WatchList.Core.Model.Load;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class FilterByMoreGradeLoadRule : ILoadRule
    {
        public FilterByMoreGradeLoadRule(ILoadRulesConfig config) => MoreGrade = config.MoreGrade;

        public Grade MoreGrade { get; private set; }

        public WatchItemCollection Apply(WatchItemCollection items)
        {
            if (MoreGrade.Value == Grade.AnyGrade.Value)
            {
                return items;
            }

            var changeItems = items.Items.Where(x => x.Grade >= MoreGrade.Value).ToList();

            return new WatchItemCollection(changeItems);
        }
    }
}
