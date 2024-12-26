using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Model.Sortable;

namespace WatchList.WPF.Models.Sorter
{
    public class SortItemsModel<T> : ObservableObject, ISortItem<T>
    {
        private readonly ISortItem<T> _sortType;

        public SortItemsModel(ISortItem<T> sortType)
        {
            if (sortType == null || sortType.Items.Count == decimal.Zero)
            {
                throw new ArgumentNullException("Error loading sort fields.");
            }

            _sortType = sortType;
        }

        public IEnumerable<ISortableSmartEnum<T>> SortFields
        {
            get => _sortType.SortFields;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The result is not null.", nameof(value));
                }

                if (_sortType.SortFields == value)
                {
                    return;
                }

                _sortType.SortFields = value;
                OnPropertyChanged(nameof(SortFields));
            }
        }

        public ISortableSmartEnum<T>? SortField
        {
            get => _sortType.SortField;
            set => _sortType.SortField = value;
        }

        public List<ISortableSmartEnum<T>> Items
        {
            get => _sortType.Items;
            set => _sortType.Items = value;
        }

        public IQueryable<T> Apply(IQueryable<T> items, bool? ascending = true)
            => _sortType.Apply(items, ascending);

        public virtual void Clear()
            => SortFields = new ObservableCollection<ISortableSmartEnum<T>>();
    }
}
