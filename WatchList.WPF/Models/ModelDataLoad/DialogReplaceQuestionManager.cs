using WatchList.Core.Model.QuestionResult;

namespace WatchList.WPF.Models.ModelDataLoad
{
    public class DialogReplaceQuestionManager
    {
        public DialogReplaceQuestionManager()
        {
        }

        public DialogReplaceItemQuestion DialogReplaceItemQuestion { get; private set; } = DialogReplaceItemQuestion.Unknown;

        public void UpdateData(DialogReplaceItemQuestion dialogReplaceItemQuestion)
            => DialogReplaceItemQuestion = dialogReplaceItemQuestion;
    }
}
