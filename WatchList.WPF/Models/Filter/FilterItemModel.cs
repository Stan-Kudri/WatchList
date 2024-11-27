using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WPF.Models.Filter
{
    public class FilterItemModel : BindableBase, IFilterItem
    {
        private IEnumerable<TypeCinema> _filterTypeField;
        private IEnumerable<StatusCinema> _filterStatusField;

        public FilterItemModel()
        {
            SelectTypeField = TypeItems.Select(e => e.ToString()).ToArray();
            SelectStatusField = StatusItems.Select(e => e.ToString()).ToArray();
            _filterTypeField = TypeCinema.List;
            _filterStatusField = StatusCinema.List;
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

                SetValue(ref _filterTypeField, value);
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

                SetValue(ref _filterStatusField, value);
            }
        }

        public ObservableCollection<TypeCinema> TypeItems { get; set; }
            = new ObservableCollection<TypeCinema>(TypeCinema.List);

        public ObservableCollection<StatusCinema> StatusItems { get; set; }
            = new ObservableCollection<StatusCinema>(StatusCinema.List);

        public FilterWatchItem GetFilter() => new FilterWatchItem(_filterTypeField, _filterStatusField);

        public void Clear()
        {
            FilterTypeField = new HashSet<TypeCinema>(TypeCinema.List);
            FilterStatusField = new HashSet<StatusCinema>(StatusCinema.List);
        }
    }
}
