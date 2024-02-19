using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WatchList.Core.Model.Sortable;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Sorter
{
    public class SortItemsModel<T> : ISortItem<T>
    {
        private event PropertyChangedEventHandler PropertyChanged;

        private readonly ISortItem<T> _sortType;

        public SortItemsModel(ISortItem<T> sortType)
        {
            _sortType = sortType;

            if (Items == null || Items.Count == decimal.Zero)
            {
                throw new Exception("Error loading sort fields.");
            }

            SelectField = Items.Select(e => e.ToString()).ToArray();
        }

        public string[] SelectField { get; }

        public IQueryable<T> Apply(IQueryable<T> items, bool? ascending = true)
            => _sortType.Apply(items, ascending);

        public void Clear()
            => SortFields = new HashSet<ISortableSmartEnum<T>>();

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
                OnPropertyChanged(nameof(_sortType.SortFields));
            }
        }

        public ISortableSmartEnum<T> SortField
        {
            get => _sortType.SortField;
            set => _sortType.SortField = value;
        }

        public ObservableCollection<ISortableSmartEnum<T>> Items
        {
            get => _sortType.Items;
            set => _sortType.Items = value;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
