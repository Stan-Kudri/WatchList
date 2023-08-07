using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;

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
                    Where(x => x.TitleNormalized == item.TitleNormalized && x.Sequel == item.Sequel && x.Type == item.Type).
                    Take(2).Select(x => x.Id).ToList();
    }
}
