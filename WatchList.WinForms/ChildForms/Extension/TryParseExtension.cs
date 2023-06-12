namespace WatchList.WinForms.ChildForms.Extension
{
    public static class TryParseExtension
    {
        public static Guid ParseGuid(this string? str)
        {
            if (!Guid.TryParse(str, out var value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }

            return value;
        }

        public static int ParseInt(this string? str)
        {
            if (!int.TryParse(str, out var value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }

            return value;
        }

        public static decimal ParseDecimal(this string? str)
        {
            if (!decimal.TryParse(str, out var value))
            {
                throw new InvalidOperationException("Invalid cast.");
            }

            return value;
        }

        public static decimal ToDecimal(this int? valueInt) => Convert.ToDecimal(valueInt);
    }
}
