using WatchList.Core.Service.Component;

namespace WatchList.WinForms.Message
{
    public class MessageBoxShow : IMessageBox
    {
        public void ShowInfo(string message) => MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void ShowWarning(string message) => MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public bool ShowQuestion(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public bool ShowQuestionSaveItem(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
    }
}
