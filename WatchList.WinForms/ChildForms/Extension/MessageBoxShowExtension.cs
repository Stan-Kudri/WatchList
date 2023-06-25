using WatchList.Core.Model.QuestionResult;
using WatchList.WinForms.ChildForms.MessageBoxForm;

namespace WatchList.WinForms.ChildForms.Extension
{
    public static class MessageBoxShowExtension
    {
        public static DialogResultQuestion ShowQuestionReplace(this string titleItem)
        {
            var questForm = new QuestionMessageBoxForm(titleItem);
            if (questForm.ShowDialog() == DialogResult.OK)
            {
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
            }

            return DialogResultQuestion.Unknown;
        }
    }
}
