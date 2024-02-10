using MudBlazor;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;
using WatchList.MudBlazors.Extension;

namespace WatchList.MudBlazors.Message
{
    public class MessageBoxDialog : IMessageBox
    {
        private readonly IDialogService _dialogService;

        public MessageBoxDialog(IDialogService dialogService)
            => _dialogService = dialogService;

        public DialogReplaceItemQuestion ShowDataReplaceQuestion(string titleItem)
            => DialogReplaceItemQuestion.Yes;

        public void ShowError(string message)
            => _dialogService.ShowMessageBox("Error", message, yesText: "Ok");

        public void ShowInfo(string message)
            => _dialogService.ShowMessageBox("Information", message, yesText: "Ok");

        public bool ShowQuestion(string message)
            => _dialogService.DialogYesNoShow("Question", message);

        public bool ShowQuestionSaveItem(string message)
            => _dialogService.DialogYesNoShow("Question", message);

        public void ShowWarning(string message)
            => _dialogService.ShowMessageBox("Warning", message, yesText: "Ok");
    }
}
