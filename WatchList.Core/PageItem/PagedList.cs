using System.Collections;

namespace WatchList.Core.PageItem
{
    public class PagedList<T> : IReadOnlyCollection<T>
    {
        protected const int StartPageSize = 10;
        protected const int NumberStartPage = 1;

        public PagedList(IQueryable<T> items, int pageNumber = NumberStartPage, int pageSize = StartPageSize)
            : this(GetPage(items, pageNumber, pageSize), pageNumber, pageSize, items.Count())
        {
        }

        public PagedList(IEnumerable<T> items, int pageNumber = NumberStartPage, int pageSize = StartPageSize)
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

            Items = items.Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        public virtual int PageNumber { get; protected set; } = NumberStartPage;

        public int TotalItems { get; private set; } = 0;

        public int PageSize { get; private set; } = StartPageSize;

        public List<T> Items { get; private set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < Count;

        public bool HasEmptyPage => Count == 0;

        public int Count => PageSize != 0 ? (int)Math.Ceiling((double)TotalItems / PageSize) : 0;

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static List<T> GetPage(IQueryable<T> items, int pageNumber, int pageSize)
            => items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        private static List<T> GetPage(IEnumerable<T> items, int pageNumber, int pageSize)
            => items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
}
