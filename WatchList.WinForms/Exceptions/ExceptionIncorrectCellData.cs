namespace WatchList.WinForms.Exceptions
{
    public class ExceptionIncorrectCellData : ApplicationException
    {
        public ExceptionIncorrectCellData(string message)
            : base(message)
        {
        }

        public ExceptionIncorrectCellData(string message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public ExceptionIncorrectCellData(DataGridViewRow rowItem, int indexColumn)
            : base($"In cell row {rowItem.Index} column {indexColumn} the data cannot be converted to a string")
        {
        }
    }
}
