using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.Db;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository
{
    public class WatchItemRepository : IWatchItemRepository
    {
        private readonly WatchCinemaDbContext _db;

        public WatchItemRepository(WatchCinemaDbContext db) => _db = db;

        public PagedList<WatchItem> GetPage(WatchItemSearchRequest searchRequest)
        {
            var query = searchRequest.ApplyFilter(_db.WatchItem);
            query = searchRequest.ApplyOrderBy(query);
            return query.GetPagedList(searchRequest.Page);
        }

        public void Add(WatchItem item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void RemoveRange() => _db.WatchItem.ExecuteDelete();

        public void Remove(Guid id)
        {
            var selectItem = _db.WatchItem.Where(x => x.Id == id);
            if (selectItem.Count() != 1)
            {
                throw new InvalidOperationException("Interaction element not found.");
            }
            else
            {
                selectItem.ExecuteDelete();
            }
        }

        public void Update(WatchItem editItem)
        {
            if (editItem == null)
            {
                throw new ArgumentNullException("The received parameters are not correct.");
            }

            var item = _db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id) ?? throw new InvalidOperationException("Interaction element not found.");

            item.Sequel = editItem.Sequel;
            item.Date = editItem.Date;
            item.Grade = editItem.Grade;
            item.Title = editItem.Title;
            item.Type = editItem.Type;
            item.Status = editItem.Status;

            _db.SaveChanges();
        }
    }
}
