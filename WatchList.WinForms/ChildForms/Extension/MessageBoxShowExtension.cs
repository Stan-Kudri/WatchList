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

                switch (questResult)
                {
                    case QuestionResultEnum.Yes:
                        return DialogReplaceItemQuestion.Yes;
                    case QuestionResultEnum.AllYes:
                        return DialogReplaceItemQuestion.AllYes;
                    case QuestionResultEnum.No:
                        return DialogReplaceItemQuestion.No;
                    case QuestionResultEnum.AllNo:
                        return DialogReplaceItemQuestion.AllNo;
                }
            }

            return DialogReplaceItemQuestion.Unknown;
        }
    }
}
