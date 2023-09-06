using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class DeleteGradeRule : ILoadRule
    {
        public DeleteGradeRule(ILoadRulesConfig config) => IsDeleteGrade = config.DeleteGrade;

        public bool IsDeleteGrade { get; private set; }

        public WatchItemCollection Apply(WatchItemCollection items)
        {
            if (!IsDeleteGrade)
            {
                return items;
            }

            foreach (var item in items.Items)
            {
                if (item.Grade == null)
                {
                    continue;
                }

                item.Status = StatusCinema.Planned;
                item.Date = null;
                item.Grade = null;
            }

            return items;
        }
    }
}
