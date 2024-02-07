using WatchList.Core.PageItem;

namespace WatchList.Core.Repository.Extension
{
    public static class PageDateExtension
    {
        public static PagedList<T> GetPagedList<T>(this IQueryable<T> self, Page page)
            => new PagedList<T>(self, page.Number, page.Size);
    }
}
