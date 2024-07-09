namespace WatchList.WinForms.Exceptions
{
    public class ExceptionSelectValueInComboBox : ApplicationException
    {
        public ExceptionSelectValueInComboBox(string message)
            : base(message)
        {
        }

        public ExceptionSelectValueInComboBox(string message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
