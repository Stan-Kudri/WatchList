using System.Collections;

namespace WatchList.Core.PageItem
{
    public class PagedList<T> : ICollection<T>
    {
        private const int StartPageSize = 5;
        private const int NumberStartPage = 1;

        public PagedList(IQueryable<T> items, int pageNumber = NumberStartPage, int pageSize = StartPageSize)
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

        public int PageNumber { get; private set; } = NumberStartPage;

        public int TotalItems { get; private set; } = 0;

        public int PageSize { get; private set; } = StartPageSize;

        public List<T> Items { get; private set; }

        public int PageCount => PageSize != 0 ? (int)Math.Ceiling((double)TotalItems / PageSize) : 0;

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < PageCount;

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException("The element has already been added to the collection.", nameof(item));
            }
            else
            {
                Items.Add(item);
            }
        }

        public void Clear() => Items.Clear();

        public bool Contains(T item)
        {
            foreach (var element in Items)
            {
                if (item != null || item.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The array cannot be null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            }
            else if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The destination array has fewer elements than the collection.");
            }

            for (var i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = Items[i];
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                Items.Remove(item);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static List<T> GetPage(IQueryable<T> items, int pageNumber, int pageSize)
            => items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
}
