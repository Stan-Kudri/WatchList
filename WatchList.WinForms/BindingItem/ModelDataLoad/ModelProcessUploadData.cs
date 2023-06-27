namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData
    {
        public ModelProcessUploadData(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }
    }
}
