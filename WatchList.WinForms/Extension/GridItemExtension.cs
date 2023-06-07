namespace WatchList.WinForms.Extension
{
    public static class GridItemExtension
    {
        private const int IndexColumnId = 5;

        public static Guid? IdRowItem(this DataGridViewRow dataRow) => (Guid?)dataRow.Cells[IndexColumnId].Value;

        public static Guid IdRowItem(this DataGridView dataGrid, int index) => (Guid)dataGrid.Rows[index].Cells[IndexColumnId].Value;
    }
}
