namespace WatchList.WinForms.BindingItem.ModelDataLoadingAlgorithm
{
    public class ModelProcessUploadData
    {
        public ModelProcessUploadData(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }
    }
}
