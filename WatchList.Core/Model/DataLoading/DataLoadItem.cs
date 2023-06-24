using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.DataLoading
{
    public class DataLoadItem
    {
        public DataLoadItem(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }

        public List<WatchItem> LoadItem(List<WatchItem> items)
        {
            if (!IsDeleteGrade ||
                !items.Where(x => x.Date != null).Any())
            {
                return items;
            }

            foreach (var item in items)
            {
                if (item.Grade != null)
                {
                    item.Status = StatusCinema.Planned;
                    item.Date = null;
                    item.Grade = null;
                }
            }

            return items;
        }
    }
}
