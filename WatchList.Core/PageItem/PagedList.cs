namespace WatchList.Core.PageItem
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> items, int pageNumber, int pageSize)
            : this(GetPage(items, pageNumber, pageSize), pageNumber, pageSize, items.Count())
        {
        }

        public PagedList(List<T> items, int pageNumber, int pageSize, int totalItems)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (pageNumber < 0)
            {
                throw new ArgumentException("Page number can not be less than zero.", nameof(pageNumber));
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException("Page size can not be less than one.", nameof(pageSize));
            }

            if (totalItems < 0)
            {
                throw new ArgumentException("Total items can not be less than zero.", nameof(totalItems));
            }

            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        public int PageNumber { get; private set; } = 1;

        public int TotalItems { get; private set; } = 0;

        public int PageSize { get; private set; } = 5;

        public List<T> Items { get; private set; }

        public int PageCount => PageSize != 0 ? (int)Math.Ceiling((double)TotalItems / PageSize) : 0;

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < PageCount;

        private static List<T> GetPage(IQueryable<T> items, int pageNumber, int pageSize)
            => items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
}