using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;

namespace WatchList.ASP.Net.Controllers.Model
{
    //Save Item / Replace item constantly.
    public class MessageBoxStub : IMessageBox
    {
        public Task ShowError(string message)
            => Task.CompletedTask;

        public Task ShowInfo(string message)
            => Task.CompletedTask;

        public Task ShowWarning(string message)
            => Task.CompletedTask;

        public Task<bool> ShowQuestion(string message)
            => Task.FromResult(true);

        //When you try to add a duplicate, it will be updated.
        public Task<bool> ShowQuestionSaveItem(string message)
            => Task.FromResult(true);

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
            => Task.FromResult(DialogReplaceItemQuestion.AllYes);
    }
}
