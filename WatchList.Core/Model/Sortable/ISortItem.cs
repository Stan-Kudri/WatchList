using System.Collections.ObjectModel;

namespace WatchList.Core.Model.Sortable
{
    public interface ISortItem<T>
    {
        public ISortableSmartEnum<T>? SortField { get; set; }

        public IEnumerable<ISortableSmartEnum<T>> SortFields { get; set; }

        public ObservableCollection<ISortableSmartEnum<T>> Items { get; set; }

        public IQueryable<T> Apply(IQueryable<T> items, bool? ascending = true);

        public void Clear();
    }
}
