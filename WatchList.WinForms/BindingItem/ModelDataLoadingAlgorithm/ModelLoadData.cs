namespace WatchList.WinForms.BindingItem.ModelDataLoadingAlgorithm
{
    public class ModelLoadData
    {
        public ModelLoadData(bool isDeleteGrade) => IsDeleteGrade = isDeleteGrade;

        public bool IsDeleteGrade { get; private set; }
    }
}
