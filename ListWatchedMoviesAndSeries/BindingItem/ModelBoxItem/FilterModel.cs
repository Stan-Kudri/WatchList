using System.Collections.ObjectModel;
using Core.ItemFilter;
using Core.Model;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class FilterModel : ModelBase
    {
        private TypeFilter _type = Core.ItemFilter.TypeFilter.AllCinema;
        private StatusFilter _status = Core.ItemFilter.StatusFilter.AllCinema;

        public ObservableCollection<TypeFilter> TypeFilter { get; set; } = new ObservableCollection<TypeFilter>(Core.ItemFilter.TypeFilter.List);

        public ObservableCollection<StatusFilter> StatusFilter { get; set; } = new ObservableCollection<StatusFilter>(Core.ItemFilter.StatusFilter.List);

        public TypeFilter Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public StatusFilter Status
        {
            get => _status;
            set => SetField(ref _status, value);
        }

        public FilterItem GetFilter()
        {
            return new FilterItem(Type, Status);
        }
    }
}
