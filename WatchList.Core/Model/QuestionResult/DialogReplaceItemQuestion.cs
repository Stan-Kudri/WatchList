using Ardalis.SmartEnum;

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
            : base(name, (int)questionResult) => QuestionResult = questionResult;

        public QuestionResultEnum QuestionResult { get; }

        public bool IsYes
        {
            get
            {
                if (QuestionResult == QuestionResultEnum.Yes || QuestionResult == QuestionResultEnum.AllYes)
                {
                    return true;
                }
                else if (QuestionResult == QuestionResultEnum.No || QuestionResult == QuestionResultEnum.AllNo)
                {
                    return false;
                }
                else
                {
                    throw new Exception("The answer is unknown.");
                }
            }
        }
    }
}
