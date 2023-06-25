using Ardalis.SmartEnum;

namespace WatchList.Core.Model.QuestionResult
{
    public class DialogResultQuestion : SmartEnum<DialogResultQuestion>
    {
        public static readonly DialogResultQuestion Unknown = new DialogResultQuestion("Unknown", 0, QuestionResultEnum.Unknown);
        public static readonly DialogResultQuestion Yes = new DialogResultQuestion("Yes", 1, QuestionResultEnum.Yes);
        public static readonly DialogResultQuestion AllYes = new DialogResultQuestion("Yes, for all", 2, QuestionResultEnum.AllYes);
        public static readonly DialogResultQuestion AllNo = new DialogResultQuestion("No, for all", 3, QuestionResultEnum.AllNo);
        public static readonly DialogResultQuestion No = new DialogResultQuestion("No", 4, QuestionResultEnum.No);

        private DialogResultQuestion(string name, int value, QuestionResultEnum questionResult)
            : base(name, value)
        {
            QuestionResult = questionResult;
        }

        public QuestionResultEnum QuestionResult { get; }
    }
}
