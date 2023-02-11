using Core.PageItem;
using Core.Repository.DbContex;
using Core.Repository.Extension;
using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.Repository
{
    public class WatchItemRepository : IWatchItemRepository
    {
        private readonly WatchCinemaDbContext _db;

        public WatchItemRepository(WatchCinemaDbContext db)
        {
            _db = db;
        }

        public List<WatchItem> GetAll() => _db.WatchItem.ToList() ?? new List<WatchItem>();

        public PagedList<WatchItem> GetPageCinema(WatchItemSearchRequest searchRequest)
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

        public void Add(List<WatchItem> item)
        {
            _db.AddRange(item);
            _db.SaveChanges();
        }

        public void RemoveAllItems()
        {
            foreach (var item in _db.WatchItem)
            {
                _db.Remove(item);
            }
        }

        public void Remove(Guid id)
        {
            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return;

            _db.RemoveRange(item);
            _db.SaveChanges();
        }

        public void Update(WatchItem editItem)
        {
            if (editItem == null)
                return;

            var item = _db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id);
            if (item == null)
                return;

            item.NumberSequel = editItem.NumberSequel;
            item.Date = editItem.Date;
            item.Grade = editItem.Grade;
            item.Name = editItem.Name;
            item.Type = editItem.Type;
            _db.SaveChanges();
        }
    }
}
