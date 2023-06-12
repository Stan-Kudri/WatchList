using WatchList.Core.Service.Component;

namespace WatchList.WinForms.Message
{
    public class MessageBoxQuestion : IMessageBox
    {
        public bool ShowQuestionSaveItem(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
    }
}
