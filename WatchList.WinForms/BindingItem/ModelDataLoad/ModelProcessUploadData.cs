using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData : ModelBase
    {
        public ModelProcessUploadData()
        {
        }

        public ModelProcessUploadData(bool deleteGrade, TypeCinema typeCinema, Grade moreGrade)
        {
            TypeCinemaLoad = typeCinema;
            DeleteGrade = deleteGrade;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; }

        public TypeCinema TypeCinemaLoad { get; private set; }

        public Grade MoreGrade { get; private set; }
    }
}
