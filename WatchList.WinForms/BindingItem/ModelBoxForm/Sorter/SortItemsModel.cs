using WatchList.Core.Model.Sortable;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Sorter
{
    public class SortItemsModel<T> : ModelBase, ISortItem<T>
    {
        private readonly ISortItem<T> _sortType;

        public SortItemsModel(ISortItem<T> sortType)
        {
            if (sortType == null || sortType.Items.Count == decimal.Zero)
            {
                throw new ArgumentNullException("Error loading sort fields.");
            }

            _sortType = sortType;

            SelectField = Items.Select(e => e.ToString()).ToArray();
        }

        public string[] SelectField { get; }

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
            => SortFields = new HashSet<ISortableSmartEnum<T>>();
    }
}
