namespace WatchList.Core.Model.Sortable
{
    public interface ISortItem<T>
    {
        ISortableSmartEnum<T>? SortField { get; set; }

        IEnumerable<ISortableSmartEnum<T>> SortFields { get; set; }

        List<ISortableSmartEnum<T>> Items { get; set; }

        IQueryable<T> Apply(IQueryable<T> items, bool? ascending = true);

        void Clear();
    }
}
