using WatchList.Core.Model.QuestionResult;

namespace WatchList.Core.Service.Component
{
    public interface IMessageBox
    {
        Task ShowInfo(string message);

        Task ShowWarning(string message);

        Task ShowError(string message);

        Task<bool> ShowQuestion(string message);

        Task<bool> ShowQuestionSaveItem(string message);

        Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem);
    }
}
