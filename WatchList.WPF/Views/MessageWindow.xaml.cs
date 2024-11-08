using System.Windows;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;
using MessageBoxWindow = System.Windows.MessageBox;

namespace WatchList.WPF.Views
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window, IMessageBox
    {
        public MessageWindow()
        {
            InitializeComponent();
        }

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
        {
            throw new NotImplementedException();
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
