using System.Collections.ObjectModel;
using Core.Model.Filter;
using Core.Model.Filter.Components;

namespace ListWatchedMoviesAndSeries.BindingItem.ModelBoxForm
{
    public class FilterModel : ModelBase
    {
        private TypeFilter _type = Core.Model.Filter.Components.TypeFilter.AllCinema;
        private StatusFilter _status = Core.Model.Filter.Components.StatusFilter.AllCinema;

        public ObservableCollection<TypeFilter> TypeFilter { get; set; } = new ObservableCollection<TypeFilter>(Core.Model.Filter.Components.TypeFilter.List);

        public ObservableCollection<StatusFilter> StatusFilter { get; set; } = new ObservableCollection<StatusFilter>(Core.Model.Filter.Components.StatusFilter.List);

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
