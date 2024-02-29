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

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
            => _dialogService.DialogReplaceLoadData("Updata Item", titleItem);

        public Task ShowError(string message)
            => _dialogService.ShowMessageBox(title: "Error", message, yesText: "Ok");

        public Task ShowInfo(string message)
            => _dialogService.ShowMessageBox(title: "Information", message, yesText: "Ok");

        public Task<bool> ShowQuestion(string message)
            => _dialogService.DialogYesNoShow(title: "Question", message);

        public Task<bool> ShowQuestionSaveItem(string message)
            => _dialogService.DialogYesNoShow(title: "Question", message);

        public Task ShowWarning(string message)
            => _dialogService.ShowMessageBox(title: "Warning", message, yesText: "Ok");
    }
}
