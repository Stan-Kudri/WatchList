namespace WatchList.WinForms.Extension
{
    public static class GridItemExtension
    {
        public static T Get<T>(this DataGridViewRow dataRow, int indexColumn)
            => (T)dataRow.Cells[indexColumn].Value;

        public static string? GetString(this DataGridViewRow dateRow, int indexColumn)
            => dateRow.Cells[indexColumn].Value?.ToString();
    }
}
