namespace WatchList.Core.Model.Sortable
{
    public interface ISortableSmartEnum<T>
    {
        IOrderedQueryable<T> OrderBy(IQueryable<T> query, bool asc);

        IOrderedQueryable<T> ThenBy(IOrderedQueryable<T> query, bool asc);
    }
}
