using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository.Db;

namespace WatchList.Core.Repository.Extension
{
    public static class DuplicateIdExtension
    {
        public static Guid ReplaceIdIsNotFree(this WatchCinemaDbContext dbContext, WatchItem item)
        {
            var idDuplicate = dbContext.WatchItem.Where(x => x.Id == item.Id).Take(2).Select(x => x.Id).ToList();
            return idDuplicate.Count != 0 ? Guid.NewGuid() : item.Id;
        }
    }
}
