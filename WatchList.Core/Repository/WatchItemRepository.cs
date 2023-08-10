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
            item.Id = _db.ReplaceIdIsNotFree(item);
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var selectItem = _db.WatchItem.Where(x => x.Id == id);
            if (selectItem.ExecuteDelete() != 1)
            {
                throw new InvalidOperationException("Interaction element not found.");
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

        public List<Guid> SelectDuplicateItems(WatchItem item) =>
            _db.WatchItem.Where(x =>
                        (x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type)).
                        Take(2).Select(x => x.Id).ToList();

        public List<Guid> DuplicateItemsCaseSensitive(WatchItem item) =>
            _db.WatchItem.ToList().
                    Where(x => x.TitleNormalized == item.TitleNormalized && x.Sequel == item.Sequel && x.Type == item.Type).
                    Take(2).Select(x => x.Id).ToList();
    }
}
