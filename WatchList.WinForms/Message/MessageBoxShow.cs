using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Service.Component;
using WatchList.WinForms.ChildForms.MessageBoxForm;

namespace WatchList.WinForms.Message
{
    public class MessageBoxShow : IMessageBox
    {
        public void ShowInfo(string message) => MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void ShowWarning(string message) => MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public bool ShowQuestion(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public bool ShowQuestionSaveItem(string message) => MessageBox.Show(message, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;

        public DialogResultQuestion ShowQuestionReplaceItem(string titleItem)
        {
            var questForm = new QuestionMessageBoxForm(titleItem);
            if (questForm.ShowDialog() != DialogResult.OK)
            {
                return DialogResultQuestion.Unknown;
            }

            var questResult = questForm.ResultQuestion;

            switch (questResult)
            {
                case QuestionResultEnum.Yes:
                    return DialogResultQuestion.Yes;
                case QuestionResultEnum.AllYes:
                    return DialogResultQuestion.AllYes;
                case QuestionResultEnum.No:
                    return DialogResultQuestion.No;
                case QuestionResultEnum.AllNo:
                    return DialogResultQuestion.AllNo;
            }

            return DialogResultQuestion.Unknown;
        }
    }
}
