using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData : ModelBase
    {
        public ModelProcessUploadData()
            : this(false, false, TypeCinema.AllType, Grade.AnyGrade)
        {
        }

        public ModelProcessUploadData(bool deleteGrade, bool caseSensitive, TypeCinema typeCinema, Grade moreGrade)
        {
            DeleteGrade = deleteGrade;
            CaseSensitive = caseSensitive;
            TypeCinemaLoad = typeCinema;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; } = false;

        public bool CaseSensitive { get; private set; } = false;

        public TypeCinema TypeCinemaLoad { get; private set; } = TypeCinema.AllType;

        public Grade MoreGrade { get; private set; } = Grade.AnyGrade;
    }
}
