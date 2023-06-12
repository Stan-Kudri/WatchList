using WatchList.Core.Service.Component;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.Component
{
    public class FakeMessageBox : IMessageBox
    {
        private const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        private readonly bool _result;

        public FakeMessageBox(bool result) => _result = result;

        public bool ShowQuestion(string message = DuplicateReplaceMessage) => _result;
    }
}
