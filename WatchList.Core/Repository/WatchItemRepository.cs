using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WatchList.Core.Exceptions;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.Db;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository
{
    public class WatchItemRepository(WatchCinemaDbContext db, ILogger<WatchItemRepository> logger) : IWatchItemRepository
    {
        public PagedList<WatchItem> GetPage(ItemSearchRequest searchRequest)
        {
            var query = searchRequest.ApplyFilter(db.WatchItem.AsNoTracking());
            query = searchRequest.ApplyOrderBy(query);
            return query.GetPagedList(searchRequest.Page);
        }

        public void Add(WatchItem item)
        {
            item.Id = db.ReplaceIdIsNotFree(item);
            db.Add(item);
            db.SaveChanges();
            logger.LogInformation("Add item with ID {0}", item.Id);
        }

        public void Remove(Guid id)
        {
            var selectItem = db.WatchItem.Where(x => x.Id == id);
            if (selectItem.ExecuteDelete() != 1)
            {
                throw new InvalidOperationException("Interaction element not found.");
            }

            logger.LogInformation("Remove item with ID {0}", id);
        }

        public async Task UpdateAsync(WatchItem editItem)
        {
            BusinessLogicException.ThrowIfNull(editItem, "The received parameters are not correct.");

            var item = db.WatchItem.FirstOrDefault(x => x.Id == editItem.Id)
                        ?? throw new InvalidOperationException("Interaction element not found.");

            item.Sequel = editItem.Sequel;
            item.Date = editItem.Date;
            item.Grade = editItem.Grade;
            item.Title = editItem.Title;
            item.Type = editItem.Type;
            item.Status = editItem.Status;

            await db.SaveChangesAsync();
            logger.LogInformation($"Update Item with ID:{item.Id} on Title:{editItem.Title}");
        }

        public List<Guid> SelectDuplicateItems(WatchItem item)
             => db.WatchItem.Where(x =>
                        (x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type)).
                        Take(2).Select(x => x.Id).ToList();

        public List<Guid> DuplicateItemsCaseSensitive(WatchItem item)
            => db.WatchItem.ToList().
                    Where(x => x.TitleNormalized == item.TitleNormalized && x.Sequel == item.Sequel && x.Type == item.Type).
                    Take(2).Select(x => x.Id).ToList();

        public WatchItem GetItemById(Guid id)
            => db.WatchItem.FirstOrDefault(e => e.Id == id)
            ?? throw new ArgumentException("Interaction element not found.");
    }
}
