using System.Windows.Controls;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;

namespace WatchList.WPF.WindowBox
{
    /// <summary>
    /// Interaction logic for MessageBoxPage.xaml
    /// </summary>
    public partial class MessageBoxPage : Page, IMessageBox
    {
        public MessageBoxPage()
        {
            InitializeComponent();
        }

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
        {
            throw new NotImplementedException();
        }

        public Task ShowError(string message)
        {
            throw new NotImplementedException();
        }

        public Task ShowInfo(string message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowQuestion(string message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowQuestionSaveItem(string message)
        {
            throw new NotImplementedException();
        }

        public Task ShowWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
