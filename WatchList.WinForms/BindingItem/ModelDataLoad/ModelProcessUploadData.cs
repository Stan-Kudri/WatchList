using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData : ModelBase
    {
        public ModelProcessUploadData()
            : this(false, new ActionsWithDuplicates(), TypeCinema.AllType, Grade.AnyGrade)
        {
        }

        public ModelProcessUploadData(bool deleteGrade, ActionsWithDuplicates actionsWithDuplicates, TypeCinema typeCinema, Grade moreGrade)
        {
            DeleteGrade = deleteGrade;
            ActionsWithDuplicates = actionsWithDuplicates;
            TypeCinemaLoad = typeCinema;
            MoreGrade = moreGrade;
        }

        public bool DeleteGrade { get; private set; } = false;

        public ActionsWithDuplicates ActionsWithDuplicates { get; private set; } = new ActionsWithDuplicates();

        public TypeCinema TypeCinemaLoad { get; private set; } = TypeCinema.AllType;

        public Grade MoreGrade { get; private set; } = Grade.AnyGrade;
    }
}
