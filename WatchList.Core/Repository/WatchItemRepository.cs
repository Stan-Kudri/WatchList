using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.Db;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository
{
    public class WatchItemRepository : IWatchItemRepository
    {
        private readonly WatchCinemaDbContext _db;
        private readonly ILogger<WatchItemRepository> _logger;

        public WatchItemRepository(WatchCinemaDbContext db, ILogger<WatchItemRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public PagedList<WatchItem> GetPage(ItemSearchRequest searchRequest)
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
            _logger.LogInformation("Add item with ID {0}", item.Id);
        }

        public void Remove(Guid id)
        {
            var selectItem = _db.WatchItem.Where(x => x.Id == id);
            if (selectItem.ExecuteDelete() != 1)
            {
                throw new InvalidOperationException("Interaction element not found.");
            }

            _logger.LogInformation("Remove item with ID {0}", id);
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

            _logger.LogInformation("Edit item with ID {0}", item.Id);
        }

        public List<Guid> SelectDuplicateItems(WatchItem item)
             => _db.WatchItem.Where(x =>
                        (x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type)).
                        Take(2).Select(x => x.Id).ToList();

        public List<Guid> DuplicateItemsCaseSensitive(WatchItem item)
            => _db.WatchItem.ToList().
                    Where(x => x.TitleNormalized == item.TitleNormalized && x.Sequel == item.Sequel && x.Type == item.Type).
                    Take(2).Select(x => x.Id).ToList();

        public WatchItem GetItemById(Guid id)
            => _db.WatchItem.FirstOrDefault(e => e.Id == id)
            ?? throw new ArgumentException("Interaction element not found.");
    }
}
