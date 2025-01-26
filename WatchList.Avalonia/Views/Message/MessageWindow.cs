using System.Threading.Tasks;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.Views.Message
{
    public class MessageWindow : IMessageBox
    {
        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
            => Task.FromResult(DialogReplaceItemQuestion.AllYes);

        public Task ShowError(string message)
        {
            return Task.CompletedTask;
        }

        public Task ShowWarning(string message)
            => Task.CompletedTask;

        public Task ShowInfo(string message)
            => Task.CompletedTask;

        public Task<bool> ShowQuestion(string message)
            => Task.FromResult(true);

        public Task<bool> ShowQuestionSaveItem(string message)
            => Task.FromResult(true);
    }
}
