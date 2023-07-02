using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.PageItem;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class DeleteGradeRule : ILoadRule
    {
        public DeleteGradeRule(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }

        public List<WatchItem> Apply(PagedList<WatchItem> items)
        {
            if (!IsDeleteGrade)
            {
                return items.Items;
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

            return items.Items;
        }
    }
}
