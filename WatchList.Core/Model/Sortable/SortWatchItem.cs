using System.Collections.ObjectModel;
using Ardalis.SmartEnum;

namespace WatchList.Core.Model.Sortable
{
    public class SortWatchItem<T, TSortField>
        where TSortField : SmartEnum<TSortField>, ISortableSmartEnum<T>, ISortableSmartEnumOperation<T>
    {
        public ISortableSmartEnum<T> SortField { get; set; }

        public IEnumerable<ISortableSmartEnum<T>> SortFields { get; set; } = new HashSet<ISortableSmartEnum<T>>() { TSortField.DefaultValue };

        public ObservableCollection<ISortableSmartEnum<T>> Items { get; set; } = new ObservableCollection<ISortableSmartEnum<T>>(TSortField.List);

        public IQueryable<T> Apply(IQueryable<T> items, bool? ascending = true)
        {
            var sorter = new Sorter<T>(TSortField.DefaultValue);
            return sorter.Apply(items, SortFields, ascending);
        }

        public void Clear()
            => SortFields = new HashSet<ISortableSmartEnum<T>>()
            {
                TSortField.DefaultValue,
            };
    }
}
