using System.Threading.Tasks;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using WatchList.Avalonia.Data;
using WatchList.Avalonia.Extension;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;

namespace WatchList.Avalonia.Views.Message
{
    public class MessageWindow : IMessageBox
    {
        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
            => titleItem.GetDialogReplaceItem();

        public Task ShowError(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(Constans.ErrorMessage, message, ButtonEnum.Ok);
            var result = box.ShowAsync();
            return Task.CompletedTask;
        }

        public Task ShowWarning(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(Constans.WarningMessage, message, ButtonEnum.Ok);
            var result = box.ShowAsync();
            return Task.CompletedTask;
        }

        public Task ShowInfo(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(Constans.InformationMessage, message, ButtonEnum.Ok);
            var result = box.ShowAsync();
            return Task.CompletedTask;
        }

        public async Task<bool> ShowQuestion(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(Constans.QuestionMessage, message, ButtonEnum.YesNo);
            var result = await box.ShowWindowAsync();
            return await (result == ButtonResult.Yes ? Task.FromResult(true) : Task.FromResult(false));
        }

        public async Task<bool> ShowQuestionSaveItem(string message)
        {
            var box = MessageBoxManager.GetMessageBoxStandard(Constans.QuestionMessage, message, ButtonEnum.OkCancel);
            var result = await box.ShowWindowAsync();
            return await (result == ButtonResult.Ok ? Task.FromResult(true) : Task.FromResult(false));
        }
    }
}
