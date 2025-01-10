using Ardalis.SmartEnum;
using WatchList.Core.Enums;

namespace WatchList.Core.Model.QuestionResult
{
    public class DialogReplaceItemQuestion : SmartEnum<DialogReplaceItemQuestion>
    {
        public static readonly DialogReplaceItemQuestion Unknown = new DialogReplaceItemQuestion("Unknown", QuestionResultEnum.Unknown);
        public static readonly DialogReplaceItemQuestion Yes = new DialogReplaceItemQuestion("Yes", QuestionResultEnum.Yes);
        public static readonly DialogReplaceItemQuestion AllYes = new DialogReplaceItemQuestion("Yes, for all", QuestionResultEnum.AllYes);
        public static readonly DialogReplaceItemQuestion AllNo = new DialogReplaceItemQuestion("No, for all", QuestionResultEnum.AllNo);
        public static readonly DialogReplaceItemQuestion No = new DialogReplaceItemQuestion("No", QuestionResultEnum.No);

        private DialogReplaceItemQuestion(string name, QuestionResultEnum questionResult)
            : base(name, (int)questionResult)
            => QuestionResult = questionResult;

        public QuestionResultEnum QuestionResult { get; }

        public bool IsYes
        {
            get
            {
                switch (QuestionResult)
                {
                    case QuestionResultEnum.Yes:
                    case QuestionResultEnum.AllYes:
                        return true;
                    case QuestionResultEnum.No:
                    case QuestionResultEnum.AllNo:
                        return false;
                    default:
                        throw new ApplicationException($"The answer is unknown. The response to the request was sent by the user incorrectly. Property => {nameof(QuestionResult)}");
                }
            }
        }
    }
}
