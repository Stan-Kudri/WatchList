using System.Collections.ObjectModel;
using WatchList.Core.Model.Load.Components;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelTypeCinemaUpload : ModelBase
    {
        private TypeLoadingCinema _type = new TypeLoadingCinema();

        public ModelTypeCinemaUpload()
            : this(new TypeLoadingCinema())
        {
        }

        public ModelTypeCinemaUpload(TypeLoadingCinema type)
            => SelectedValue = type;

        public ObservableCollection<TypeLoadingCinema> Items { get; set; }
            = TypeLoadingCinema.GetItemsType;

        public TypeLoadingCinema SelectedValue
        {
            get => _type;
            set => SetField(ref _type, value);
        }
    }
}
