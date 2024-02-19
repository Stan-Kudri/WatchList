using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelBoxForm.Filter
{
    public class FilterItemModel : IFilterItem
    {
        private IEnumerable<TypeCinema> _filterTypeField;
        private IEnumerable<StatusCinema> _filterStatusField;

        private event PropertyChangedEventHandler PropertyChanged;

        public FilterItemModel()
        {
            SelectTypeField = TypeItems.Select(e => e.ToString()).ToArray();
            SelectStatusField = StatusItems.Select(e => e.ToString()).ToArray();
            _filterTypeField = TypeCinema.List.Where(e => e != TypeCinema.AllType).AsEnumerable();
            _filterStatusField = StatusCinema.List.Where(e => e != StatusCinema.AllStatus).AsEnumerable();
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

        public ObservableCollection<TypeCinema> TypeItems { get; set; }
            = new ObservableCollection<TypeCinema>(TypeCinema.List.Where(e => e != TypeCinema.AllType));

        public ObservableCollection<StatusCinema> StatusItems { get; set; }
            = new ObservableCollection<StatusCinema>(StatusCinema.List.Where(e => e != StatusCinema.AllStatus));

        public FilterWatchItem GetFilter() => new FilterWatchItem(_filterTypeField, _filterStatusField);

        public void Clear()
        {
            FilterTypeField = new HashSet<TypeCinema>(TypeCinema.List.Where(e => e != TypeCinema.AllType));
            FilterStatusField = new HashSet<StatusCinema>(StatusCinema.List.Where(e => e != StatusCinema.AllStatus));
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
