using System.Windows;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;
using WatchList.WPF.Models.ModelDataLoad;
using MessageBoxWindow = System.Windows.MessageBox;

namespace WatchList.WPF.Views.Message
{
    public class MessageWindow : Window, IMessageBox
    {
        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
        {
            var replaceQuestionManager = new DialogReplaceQuestionManager();
            var windowDataReplaceItem = new DataReplaceMessageWindow(titleItem, replaceQuestionManager);

            return windowDataReplaceItem.ShowDialog() == true
                ? Task.FromResult(replaceQuestionManager.DialogReplaceItemQuestion)
                : Task.FromResult(DialogReplaceItemQuestion.Unknown);
        }

        public Task ShowError(string message)
        {
            MessageBoxWindow.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return Task.CompletedTask;
        }

        public Task ShowWarning(string message)
        {
            MessageBoxWindow.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            return Task.CompletedTask;
        }

        public Task ShowInfo(string message)
        {
            MessageBoxWindow.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            return Task.CompletedTask;
        }

        public Task<bool> ShowQuestion(string message)
        {
            var result = MessageBoxWindow.Show(message, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes ? Task.FromResult(true) : Task.FromResult(false);
        }

        public Task<bool> ShowQuestionSaveItem(string message)
        {
            var result = MessageBoxWindow.Show(message, "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            return result == MessageBoxResult.OK ? Task.FromResult(true) : Task.FromResult(false);
        }
    }
}
