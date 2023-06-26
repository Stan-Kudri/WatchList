using WatchList.Core.Model.QuestionResult;
using WatchList.WinForms.ChildForms.MessageBoxForm;

namespace WatchList.WinForms.ChildForms.Extension
{
    public static class MessageBoxShowExtension
    {
        public static DialogReplaceItemQuestion ShowQuestionReplace(this string titleItem)
        {
            var questForm = new DataReplaceMessageForm(titleItem);
            if (questForm.ShowDialog() == DialogResult.OK)
            {
                var questResult = questForm.ResultQuestion;
                return DialogReplaceItemQuestion.FromValue((int)questResult);
            }

            return DialogReplaceItemQuestion.Unknown;
        }
    }
}
