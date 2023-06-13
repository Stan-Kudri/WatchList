namespace WatchList.WinForms.ChildForms.Extension
{
    public static class ParseExtension
    {
        public static Guid ParseGuid(this string? str) =>
            Guid.TryParse(str, out var value) ? value : throw new InvalidOperationException("Invalid cast.");

        public static int ParseInt(this string? str) =>
            int.TryParse(str, out var value) ? value : throw new InvalidOperationException("Invalid cast.");

        public static decimal ParseDecimal(this string? str) =>
            decimal.TryParse(str, out var value) ? value : throw new InvalidOperationException("Invalid cast.");

        public static decimal ToDecimal(this int? valueInt) =>
            valueInt != null ? Convert.ToDecimal(valueInt) : throw new InvalidOperationException("Invalid cast.");
    }
}
