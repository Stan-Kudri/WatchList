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

        public PagedList<WatchItem> GetPagedList(WatchItemSearchRequest searchRequest)
        {
            var query = searchRequest.Apply(_db.WatchItem).OrderBy(x => x.Name);
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

        public void RemoveRange()
        {
            foreach (var iteb in _db.WatchItem)
            {
                _db.Remove(iteb);
            }
        }

        public void Remove(Guid id)
        {
            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return;

            _db.WatchItem.Remove(item);
            _db.SaveChanges();
        }

        public void Update(WatchItem editItem)
        {
            if (editItem == null)
                return;

            var item = _db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id);
            if (item == null)
                return;

            item.NumberSequel = editItem.NumberSequel ?? 0;
            item.Detail = editItem.Detail;
            item.Name = editItem.Name;
            _db.SaveChanges();
        }
    }
}
