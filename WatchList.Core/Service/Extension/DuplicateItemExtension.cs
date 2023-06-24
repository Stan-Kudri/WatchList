using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository.Db;

namespace WatchList.Core.Service.Extension
{
    public static class DuplicateItemExtension
    {
        public static List<Guid> SelectIdItemsByDuplicate(this WatchCinemaDbContext dbContext, WatchItem item) =>
            dbContext.WatchItem.Where(x =>
                        (x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type)
                        || x.Id == item.Id).
                        Take(2).Select(x => x.Id).ToList();
    }
}
