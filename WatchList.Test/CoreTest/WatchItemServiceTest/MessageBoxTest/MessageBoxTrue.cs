using WatchList.Core.Service.Component;

namespace WatchList.Test.CoreTest.WatchItemServiceTest.MessageBoxTest
{
    public class MessageBoxTrue : IMessageBox
    {
        public bool ShowQuestion(string message) => true;
    }
}
