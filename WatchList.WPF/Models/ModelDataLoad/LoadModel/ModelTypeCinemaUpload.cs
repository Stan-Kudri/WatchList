using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using WatchList.Core.Model.Load.Components;

namespace WatchList.WPF.Models.ModelDataLoad.LoadModel
{
    public class ModelTypeCinemaUpload : BindableBase
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
            set => SetValue(ref _type, value, nameof(SelectedValue));
        }
    }
}
