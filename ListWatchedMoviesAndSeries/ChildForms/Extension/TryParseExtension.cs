using System.ComponentModel;

namespace ListWatchedMoviesAndSeries.ChildForms.Extension
{
    public static class TryParseExtension
    {
        public static void ParseItem<T>(this string? str, out T value)
        {
            if (str == null)
            {
                throw new ArgumentException("Value cannot be null.");
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(str);
            }
            catch
            {
                throw new InvalidOperationException("Invalid cast.");
            }
        }
    }
}
