namespace ListWatchedMoviesAndSeries.ChildForms.Extension
{
    public static class TryParseExtension
    {
        public static void ParseGuid(this string? str, out Guid value)
        {
            if (!Guid.TryParse(str, out value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }
        }

        public static void ParseInt(this string? str, out int value)
        {
            if (!int.TryParse(str, out value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }
        }

        public static void ParseDecimal(this string? str, out decimal value)
        {
            if (!decimal.TryParse(str, out value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }
        }
    }
}
