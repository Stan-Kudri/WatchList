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

        public void AddAllItem(List<WatchItem> item)
        {
            foreach (var element in item)
            {
                _db.Add(element);
                _db.SaveChanges();
            }
        }

        public void Delite(Guid id)
        {
            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);
            if (item != null)
                _db.WatchItem.Remove(item);
            _db.SaveChanges();
        }

        public void UpDate(WatchItem item)
        {
            if (item != null)
            {
                _db.WatchItem.Update(item);
                _db.SaveChanges();
            }
        }
    }
}
