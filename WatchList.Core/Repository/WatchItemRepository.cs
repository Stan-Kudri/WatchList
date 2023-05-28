using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.DbContext;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository
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
            if (HasForDuplicateItem(item))
            {
                _db.Add(item);
                _db.SaveChanges();
            }
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
                return;
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

            _db.SaveChanges();
        }

        private bool HasForDuplicateItem(WatchItem watchItem)
        {
            var item = _db.WatchItem.FirstOrDefault(x =>
             (x.Title == watchItem.Title && x.Sequel == watchItem.Sequel && x.Type == watchItem.Type)
             || x.Id == watchItem.Id);

            if (item == null)
            {
                return true;
            }

            return false;
        }
    }
}
