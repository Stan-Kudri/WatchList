using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;
using WatchList.WinForms.ChildForms.MessageBoxForm;

namespace WatchList.WinForms.Message
{
    public class MessageBoxShow : IMessageBox
    {
        public Task ShowInfo(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return Task.CompletedTask;
        }

        public Task ShowWarning(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return Task.CompletedTask;
        }

        public Task ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return Task.CompletedTask;
        }

        public Task<bool> ShowQuestion(string message)
            => Task.FromResult(MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

        public Task<bool> ShowQuestionSaveItem(string message)
            => Task.FromResult(MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK);

        public Task<DialogReplaceItemQuestion> ShowDataReplaceQuestion(string titleItem)
        {
            using (var form = new DataReplaceMessageForm(titleItem))
            {
                var res = form.ShowDialog() == DialogResult.OK ?
                    DialogReplaceItemQuestion.FromValue((int)form.ResultQuestion) :
                    DialogReplaceItemQuestion.Unknown;
                return Task.FromResult(res);
            }
        }
    }
}
