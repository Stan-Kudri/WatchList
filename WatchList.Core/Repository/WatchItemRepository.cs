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
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Add(List<WatchItem> listItems)
        {
            foreach (var item in listItems)
            {
                _db.Add(item);
            }

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

        public void Update(WatchItem editItem) => UpdateByID(editItem, editItem.Id);

        public void UpdateByID(WatchItem editItem, Guid? id)
        {
            if (editItem == null || id == null)
            {
                throw new ArgumentException("The received parameters are not correct.");
            }

            var item = _db.WatchItem.FirstOrDefault(x => x.Id == id);

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
    }
}
