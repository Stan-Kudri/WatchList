using Core.Repository.DbContex;
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

        public void Add(WatchItem item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _db.WatchItem.Remove(item);
            _db.SaveChanges();
        }

        public void UpDate(WatchItem editItem)
        {
            if (editItem != null)
            {
                var item = _db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id);
                if (item != null)
                {
                    item.NumberSequel = editItem.NumberSequel ?? 0;
                    item.Detail = editItem.Detail;
                    item.Name = editItem.Name;
                    _db.SaveChanges();
                }
            }
        }
    }
}
