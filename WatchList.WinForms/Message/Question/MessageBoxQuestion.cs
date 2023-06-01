namespace WatchList.WinForms.Message.Question
{
    public class MessageBoxQuestion : IMessageBox
    {
        public bool ShowQuestion(string message)
        {
            var dialogResult = MessageBoxProvider.ShowQuestionSaveItem(message);
            if (dialogResult)
            {
                return true;
            }

            return false;
        }
    }
}
