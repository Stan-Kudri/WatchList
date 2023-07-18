using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository.Db;

namespace WatchList.Core.Service.Extension
{
    public static class DuplicateItemExtension
    {
        public static List<Guid> SelectDuplicateItems(this DbSet<WatchItem> dbSet, WatchItem item) =>
            dbSet.Where(x =>
                        (x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type)).
                        Take(2).Select(x => x.Id).ToList();

        public static List<Guid> DuplicateItemsCaseSensitive(this DbSet<WatchItem> dbSet, WatchItem item) =>
            dbSet.ToList().
                    Where(x => x.Title.ToLower() == item.Title.ToLower() && x.Sequel == item.Sequel && x.Type == item.Type).
                    Take(2).Select(x => x.Id).ToList();

        public static Guid ReplaceIdIsNotFree(this WatchCinemaDbContext dbContext, WatchItem item)
        {
            var idDuplicate = dbContext.WatchItem.Where(x => x.Id == item.Id).Take(2).Select(x => x.Id).ToList();
            return idDuplicate.Count != 0 ? Guid.NewGuid() : item.Id;
        }
    }
}
