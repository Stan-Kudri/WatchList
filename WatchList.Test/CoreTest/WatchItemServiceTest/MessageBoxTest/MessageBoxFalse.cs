using WatchList.Core.Service.Component;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.MessageBoxTest
{
    public class MessageBoxFalse : IMessageBox
    {
        public bool ShowQuestion(string message) => false;
    }
}
