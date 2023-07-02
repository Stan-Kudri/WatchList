namespace WatchList.WinForms.BindingItem.ModelDataLoad
{
    public class ModelProcessUploadData
    {
        public ModelProcessUploadData(bool isDeleteGrade) => DeleteGrade = isDeleteGrade;

        public bool DeleteGrade { get; private set; }
    }
}
