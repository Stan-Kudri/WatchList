namespace WatchList.Core.Model.Sortable
{
    public interface ISortableSmartEnumOperation<T>
    {
        static abstract ISortableSmartEnum<T> DefaultValue { get; }

        static abstract IReadOnlyCollection<ISortableSmartEnum<T>> List { get; }
    }
}
