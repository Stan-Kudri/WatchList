using Core.PageItem;

namespace Core.Repository.Extension
{
    public static class PageDateExtension
    {
        public static PagedList<T> GetPagedList<T>(this IQueryable<T> self, Page page)
        {
            return new PagedList<T>(self, page.Number, page.Size);
        }

        /*
        public static PagedList<WatchItem> GetPagedList(this WatchCinemaDbContext db, WatchItemSearchRequest searchRequest)
        {
            var query = searchRequest.Apply(db.WatchItem).OrderBy(x => x.Name);
            return new PagedList<WatchItem>(query, searchRequest.Page.Number, searchRequest.Page.Size);
        }
        */
    }
}
