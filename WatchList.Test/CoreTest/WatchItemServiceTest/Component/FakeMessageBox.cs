using Moq;
using WatchList.Core.Service.Component;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.Component
{
    public class FakeMessageBox
    {
        private const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        private readonly bool _result;

        public FakeMessageBox(bool result) => _result = result;

        public IMessageBox SaveItem(string message = DuplicateReplaceMessage)
        {
            var messageBox = new Mock<IMessageBox>();
            messageBox.Setup(foo => foo.ShowQuestionSaveItem(message)).Returns(_result);
            return messageBox.Object;
        }
    }
}
