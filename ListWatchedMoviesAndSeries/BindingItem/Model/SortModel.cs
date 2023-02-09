using System.Collections.ObjectModel;
using Core.Model;
using Core.Model.Item;

namespace ListWatchedMoviesAndSeries.BindingItem.Model
{
    public class SortModel : ModelBase
    {
        private SortCinema _type = SortCinema.Title;

        public ObservableCollection<SortCinema> SortingObjects { get; set; } = new ObservableCollection<SortCinema>(SortCinema.List);

        public SortCinema Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public SortItem GetSortItem() => new SortItem(Type);
    }
}
