using WatchList.Core.Model.QuestionResult;

namespace WatchList.Core.Service.Component
{
    public interface IMessageBox
    {
        public Task ShowInfo(string message);

        public Task ShowWarning(string message);

        public Task ShowError(string message);

        public Task<bool> ShowQuestion(string message);

        public Task<bool> ShowQuestionSaveItem(string message);

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem);
    }
}
