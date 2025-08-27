using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Extension;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WPF.Models.Filter
{
    public class FilterItemModel : ObservableObject, IFilterItem
    {
        private IEnumerable<TypeCinema> _filterTypeField = TypeCinema.List.ToObservableCollection();
        private IEnumerable<StatusCinema> _filterStatusField = StatusCinema.List.ToObservableCollection();

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

                SetProperty(ref _filterTypeField, value);
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

                SetProperty(ref _filterStatusField, value);
            }
        }

        public List<TypeCinema> TypeItems { get; set; } = TypeCinema.List.ToListCollection();

        public List<StatusCinema> StatusItems { get; set; } = StatusCinema.List.ToListCollection();

        public FilterWatchItem GetFilter() => new FilterWatchItem(FilterTypeField, FilterStatusField);

        public void Clear()
        {
            FilterTypeField = TypeCinema.List.ToObservableCollection();
            FilterStatusField = StatusCinema.List.ToObservableCollection();
        }
    }
}
