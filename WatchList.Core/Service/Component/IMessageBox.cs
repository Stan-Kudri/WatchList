namespace WatchList.Core.Service.Component
{
    public interface IMessageBox
    {
        public void ShowInfo(string message);

        public void ShowWarning(string message);

        public void ShowError(string message);

        public bool ShowQuestion(string message);

        public bool ShowQuestionSaveItem(string message);
    }
}
