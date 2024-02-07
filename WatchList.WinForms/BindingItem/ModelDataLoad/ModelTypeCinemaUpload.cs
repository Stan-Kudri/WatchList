using System.Collections.ObjectModel;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelTypeCinemaUpload : ModelBase
    {
        private TypeCinema _type = TypeCinema.AllType;

        public ModelTypeCinemaUpload()
            : this(TypeCinema.AllType)
        {
        }

        public ModelTypeCinemaUpload(TypeCinema type)
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
