using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData : ModelBase
    {
        public ModelProcessUploadData()
        {
        }

        public ModelProcessUploadData(bool deleteGrade, TypeCinema typeCinema)
        {
            TypeCinemaLoad = typeCinema;
            DeleteGrade = deleteGrade;
        }

        public bool DeleteGrade { get; private set; }

        public TypeCinema TypeCinemaLoad { get; private set; }
    }
}
