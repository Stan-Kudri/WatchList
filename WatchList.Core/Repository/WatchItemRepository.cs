using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.DbContext;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository
{
    public class WatchItemRepository : IWatchItemRepository
    {
        private readonly WatchCinemaDbContext _db;

        public WatchItemRepository(WatchCinemaDbContext db) => _db = db;

        public List<WatchItem> GetAll() => _db.WatchItem.ToList() ?? new List<WatchItem>();

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

        public void AddRange(List<WatchItem> items)
        {
            _db.AddRange(items);
            _db.SaveChanges();
        }

        public void RemoveRange() => _db.WatchItem.ExecuteDelete();

        public void Remove(Guid id)
        {
            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return;
            }

            _db.Remove(item);
            _db.SaveChanges();
        }

        public void Update(WatchItem editItem)
        {
            if (editItem == null)
            {
                throw new ArgumentException("The received parameters are not correct.");
            }

            var item = _db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id);

            if (item == null)
            {
                return;
            }

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
