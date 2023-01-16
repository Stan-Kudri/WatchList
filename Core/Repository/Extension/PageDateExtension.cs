using Core.PageItem;
using Core.Repository.DbContex;
using ListWatchedMoviesAndSeries.Models;

namespace Core.Repository.Extension
{
    public static class PageDateExtension
    {
        public static PagedList<WatchItem> GetPagedList(this WatchCinemaDbContext db, WatchItemSearchRequest searchRequest)
        {
            var query = searchRequest.Apply(db.WatchItem).OrderBy(x => x.Name);
            return new PagedList<WatchItem>(query, searchRequest.Page.Number, searchRequest.Page.Size);
        }
    }
}
