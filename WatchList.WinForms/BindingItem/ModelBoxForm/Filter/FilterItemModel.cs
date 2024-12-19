using System.Collections.ObjectModel;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Filter
{
    public class FilterItemModel : ModelBase, IFilterItem
    {
        private IEnumerable<TypeCinema> _filterTypeField;
        private IEnumerable<StatusCinema> _filterStatusField;

        public FilterItemModel()
        {
            SelectTypeField = TypeItems.Select(e => e.ToString()).ToArray();
            SelectStatusField = StatusItems.Select(e => e.ToString()).ToArray();
            FilterTypeField = new ObservableCollection<TypeCinema>(TypeCinema.List);
            FilterStatusField = new ObservableCollection<StatusCinema>(StatusCinema.List);
        }

        public string[] SelectTypeField { get; }

        public string[] SelectStatusField { get; }

        public IEnumerable<TypeCinema> FilterTypeField
        {
            get => _filterTypeField;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The result is not null.", nameof(value));
                }

                if (_filterTypeField == value)
                {
                    return;
                }

                _filterTypeField = value;
                OnPropertyChanged(nameof(_filterTypeField));
            }
        }

        public IEnumerable<StatusCinema> FilterStatusField
        {
            get => _filterStatusField;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The result is not null.", nameof(value));
                }

                if (_filterStatusField == value)
                {
                    return;
                }

                _filterStatusField = value;
                OnPropertyChanged(nameof(_filterStatusField));
            }
        }

        public List<TypeCinema> TypeItems { get; set; }
            = new List<TypeCinema>(TypeCinema.List);

        public List<StatusCinema> StatusItems { get; set; }
            = new List<StatusCinema>(StatusCinema.List);

        public FilterWatchItem GetFilter() => new FilterWatchItem(_filterTypeField, _filterStatusField);

        public void Clear()
        {
            FilterTypeField = new ObservableCollection<TypeCinema>(TypeCinema.List);
            FilterStatusField = new ObservableCollection<StatusCinema>(StatusCinema.List);
        }
    }
}
