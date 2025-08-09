using System.Diagnostics.CodeAnalysis;

namespace WatchList.Core.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public const string MessageEmptyObject = "The passed object is empty.";

        public BusinessLogicException(string message)
            : base(message)
        {
        }

        public BusinessLogicException(string message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public static void ThrowIfNull([NotNull] object? obj, string message = MessageEmptyObject)
        {
            if (obj is null)
            {
                throw new BusinessLogicException(message);
            }
        }
    }
}
