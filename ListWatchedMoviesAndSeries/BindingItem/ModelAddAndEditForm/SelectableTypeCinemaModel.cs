using System.Collections.ObjectModel;
using Core.Model.ItemCinema.Components;

namespace ListWatchedMoviesAndSeries.BindingItem.ModelAddAndEditForm
{
    public class SelectableTypeCinemaModel : ModelBase
    {
        private TypeCinema _type = TypeCinema.Anime;

        public SelectableTypeCinemaModel()
            : this(TypeCinema.Anime)
        {
        }

        public SelectableTypeCinemaModel(TypeCinema type) => SelectedValue = type;

        public ObservableCollection<TypeCinema> Items { get; set; }
            = new ObservableCollection<TypeCinema>(TypeCinema.List.Where(x => x != TypeCinema.AllType));

        public TypeCinema SelectedValue
        {
            get => _type;
            set => SetField(ref _type, value);
        }
    }
}
