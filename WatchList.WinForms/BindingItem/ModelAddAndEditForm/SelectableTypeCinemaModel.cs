using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelAddAndEditForm
{
    public class SelectableTypeCinemaModel : ModelBase
    {
        private TypeCinema _type = TypeCinema.Anime;

        public SelectableTypeCinemaModel()
            : this(TypeCinema.Anime)
        {
        }

        public SelectableTypeCinemaModel(TypeCinema type)
            => SelectedValue = type;

        public ObservableCollection<TypeCinema> Items { get; set; }
            = new ObservableCollection<TypeCinema>(TypeCinema.List);

        public TypeCinema SelectedValue
        {
            get => _type;
            set => SetField(ref _type, value);
        }
    }
}
