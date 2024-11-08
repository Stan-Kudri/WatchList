using System.Collections.ObjectModel;
using WatchList.Core.Model.Load.Components;

namespace WatchList.WPF.Models.ModelDataLoad
{
    public class ModelTypeCinemaUpload : BindingBaseModel
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
            set
            {
                _type = value;
                OnPropertyChanged("SelectedValue");
            }
        }
    }
}
