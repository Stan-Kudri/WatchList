namespace WatchList.Core.Model.Sortable
{
    public sealed class Sorter<T>
    {
        private readonly ISortableSmartEnum<T> _defaultValue;

        public Sorter(ISortableSmartEnum<T> defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public IQueryable<T> Apply(IQueryable<T> items, IEnumerable<ISortableSmartEnum<T>> sortFields, bool? ascending = true)
        {
            if (ascending == null)
            {
                return items;
            }

            var asc = ascending.Value;
            var actualSortFields = sortFields.ToList();
            if (actualSortFields.Count == 0)
            {
                actualSortFields.Add(_defaultValue);
            }

            var query = actualSortFields[0].OrderBy(items, asc);
            foreach (var item in actualSortFields.Skip(1))
            {
                query = item.ThenBy(query, asc);
            }

            return query;
        }
    }
}
