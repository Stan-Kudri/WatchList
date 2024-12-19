using System.Collections.ObjectModel;
using WatchList.Core.Model.Load.Components;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelTypeCinemaUpload : ModelBase
    {
        private TypeCinemaModel _type = TypeCinemaModel.AllType;

        public ModelTypeCinemaUpload()
            : this(new TypeCinemaModel())
        {
        }

        public ModelTypeCinemaUpload(TypeCinemaModel type)
            => SelectedValue = type;

        public ObservableCollection<TypeCinemaModel> Items { get; set; }
            = TypeCinemaModel.GetItemsType;

        public TypeCinemaModel SelectedValue
        {
            get => _type;
            set => SetField(ref _type, value);
        }
    }
}
