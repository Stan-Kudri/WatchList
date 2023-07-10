using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Load;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class FilterByMoreGradeLoadRule : ILoadRule
    {
        public FilterByMoreGradeLoadRule(Grade moreGrade)
        {
            MoreGrade = moreGrade;
        }

        public Grade MoreGrade { get; private set; }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            if (MoreGrade.Value == Grade.NotGrade.Value)
            {
                return items;
            }

            return items.Where(x => x.Grade >= MoreGrade.Value).ToList();
        }
    }
}
