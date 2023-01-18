using Core.PageItem;

namespace Core.Repository.Extension
{
    public static class PageDateExtension
    {
        public static PagedList<T> GetPagedList<T>(this IQueryable<T> self, Page page)
        {
            return new PagedList<T>(self, page.Number, page.Size);
        }
    }
}
