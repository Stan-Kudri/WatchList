using System.Collections.ObjectModel;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Filter.Components;

namespace WatchList.WinForms.BindingItem.ModelBoxForm
{
    public class FilterModel : ModelBase
    {
        private TypeFilter _type = TypeFilter.AllCinema;
        private StatusFilter _status = StatusFilter.AllCinema;

        public ObservableCollection<TypeFilter> TypeItem { get; set; } = new ObservableCollection<TypeFilter>(TypeFilter.List);

        public ObservableCollection<StatusFilter> StatusItem { get; set; } = new ObservableCollection<StatusFilter>(StatusFilter.List);

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
