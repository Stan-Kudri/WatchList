using WatchList.Core.Service.Component;

namespace WatchList.WinForms.Message.Question
{
    public class MessageBoxQuestion : IMessageBox
    {
        public bool ShowQuestion(string message) => MessageBoxProvider.ShowQuestionSaveItem(message);
    }
}
