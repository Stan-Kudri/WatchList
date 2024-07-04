namespace WatchList.WinForms.Exceptions
{
    public class ControlException : Exception
    {
        public ControlException(string message)
            : base(message)
        {
        }

        public ControlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
