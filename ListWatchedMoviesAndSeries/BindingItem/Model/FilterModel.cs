using System.Collections.ObjectModel;
using Core.ItemFilter;
using Core.Model;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class FilterModel : ModelBase
    {
        private TypeCinemaFilter _type = TypeCinemaFilter.AllCinema;
        private WatchCinemaFilter _watch = WatchCinemaFilter.AllCinema;

        public ObservableCollection<TypeCinemaFilter> TypeFilter { get; set; } = new ObservableCollection<TypeCinemaFilter>(TypeCinemaFilter.List);

        public ObservableCollection<WatchCinemaFilter> WatchFilter { get; set; } = new ObservableCollection<WatchCinemaFilter>(WatchCinemaFilter.List);

        public TypeCinemaFilter Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public WatchCinemaFilter Watch
        {
            get => _watch;
            set => SetField(ref _watch, value);
        }

        public WatchItemFilter GetFilter()
        {
            return new WatchItemFilter(Type, Watch);
        }
    }
}
