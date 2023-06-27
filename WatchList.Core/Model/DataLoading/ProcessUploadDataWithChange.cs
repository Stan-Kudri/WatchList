using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.DataLoading
{
    public class ProcessUploadDataWithChange
    {
        public ProcessUploadDataWithChange(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }

        public List<WatchItem> PagedList(List<WatchItem> items)
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
