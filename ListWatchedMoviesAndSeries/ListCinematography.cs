using ListWatchedMoviesAndSeries.EditorForm;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
    {
        public BoxCinemaForm()
        {
            InitializeComponent();
        }

        public void SetNameGrid(WatchItem cinema)
        {
            if (cinema != null)
            {
                if (cinema.Name != null)
                {
                    if (cinema.Type == TypeCinema.Series)
                        AddCinemaGridRow(dgvSeries, cinema);

                    else if (cinema.Type == TypeCinema.Movie)
                        AddCinemaGridRow(dgvMove, cinema);

                    AddCinemaGridRow(dgvCinema, cinema);
                }
            }
        }

        public void EditItemGrid(WatchItem cinemaItem, int numberRowGridCinema, int numberRowAllGridCinema)
        {
            if (cinemaItem != null)
            {
                if (cinemaItem.Name != null)
                {
                    if (cinemaItem.Type == TypeCinema.Series)
                    {
                        ReplacementEditItem(dgvSeries, cinemaItem, numberRowGridCinema);
                    }
                    else if (cinemaItem.Type == TypeCinema.Movie)
                    {
                        ReplacementEditItem(dgvMove, cinemaItem, numberRowGridCinema);
                    }

                    ReplacementEditItem(dgvCinema, cinemaItem, numberRowAllGridCinema);
                }
            }
        }

        private void btnFormMovie_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Movie))
            {
                form.ShowDialog();
            }
        }

        private void btnFormSeries_Click(object sender, EventArgs e)
        {
            using (var form = new AddCinemaForm(this, TypeCinema.Series))
            {
                form.ShowDialog();
            }
        }

        private void btnEditCinema_Click(object sender, EventArgs e)
        {
            if (BoxName.SelectedTab == null)
            {
                return;
            }

            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (EditRowGrid(dgvMove, out int indexRowMove, out WatchItem? item))
                {
                    item.Type = TypeCinema.Movie;
                    var titleName = item?.Name;
                    var indexRowAllCinema = NumberItemGridCinema(dgvCinema, titleName);
                    using (var form = new EditorItemCinemaForm(this, item, indexRowMove, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
            else if (page == tabSeriesPage)
            {
                if (EditRowGrid(dgvSeries, out int indexRowSeries, out WatchItem? item))
                {
                    item.Type = TypeCinema.Series;
                    var titleName = item?.Name;
                    var indexRowAllCinema = NumberItemGridCinema(dgvCinema, titleName);
                    using (var form = new EditorItemCinemaForm(this, item, indexRowSeries, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
            else if (page == tabAllCinemaPage)
            {
                if (EditRowGrid(dgvCinema, out int indexRowAllCinema, out WatchItem? item))
                {
                    var titleName = item?.Name;
                    var dataGrid = CheckItemGridMove(titleName) ? dgvMove : dgvSeries;
                    var indexRow = NumberItemGridCinema(dataGrid, titleName);
                    var type = dataGrid == dgvMove ? TypeCinema.Movie : TypeCinema.Series;
                    item.Type = type;
                    using (var form = new EditorItemCinemaForm(this, item, indexRow, indexRowAllCinema))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            if (BoxName.SelectedTab == null)
            {
                return;
            }

            var page = BoxName.SelectedTab;

            if (page == tabMovePage)
            {
                if (RemoveRowGrid(dgvMove, out string? titleItem))
                    RemoveItemRowGrid(dgvCinema, titleItem);
            }
            else if (page == tabSeriesPage)
            {
                if (RemoveRowGrid(dgvSeries, out string? titleItem))
                    RemoveItemRowGrid(dgvCinema, titleItem);
            }
            else if (page == tabAllCinemaPage)
            {
                if (RemoveRowGrid(dgvCinema, out string? titleItem))
                {
                    if (CheckItemGridMove(titleItem))
                    {
                        RemoveItemRowGrid(dgvMove, titleItem);
                    }
                    else
                    {
                        RemoveItemRowGrid(dgvSeries, titleItem);
                    }
                }
            }
        }

        private bool RemoveRowGrid(DataGridView dataGridCinema, out string? name)
        {
            name = string.Empty;

            if (dataGridCinema.SelectedRows.Count == 0)
            {
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }

            name = SelectedRowCinemaName(dataGridCinema);

            for (var index = dataGridCinema.SelectedRows.Count - 1; index > -1; index--)
            {
                var grdUsersSelectedRow = dataGridCinema.SelectedRows[index];
                dataGridCinema.Rows.Remove(grdUsersSelectedRow);
            }
            return true;
        }

        private string? SelectedRowCinemaName(DataGridView gridCinema)
        {
            int rowIndex = gridCinema.CurrentCell.RowIndex;
            int columnIndex = 0; //Column "Name" in DataGridView
            return gridCinema.Rows[rowIndex].Cells[columnIndex].Value.ToString();
        }

        private void RemoveItemRowGrid(DataGridView dataGridCinema, string? title)
        {
            foreach (DataGridViewRow row in dataGridCinema.Rows)
            {
                if (row.Cells[0].Value.Equals(title))
                {
                    dataGridCinema.Rows.RemoveAt(row.Index);
                    break;
                }
            }
        }

        private void AddCinemaGridRow(DataGridView dataGridCinema, WatchItem cinema)
        {
            var partOrSeason = cinema.NumberSequel;
            string formatDate = cinema.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;
            dataGridCinema.Rows.Add(cinema.Name, partOrSeason.ToString(), cinema.GetView(), formatDate, cinema.Detail?.Grade);
        }

        private bool CheckItemGridMove(string? cinema)
        {
            var countRowGridMove = dgvMove.RowCount;
            if (countRowGridMove == 0)
                return false;

            for (int i = 0; i < countRowGridMove; i++)
            {
                var titleItem = dgvMove.Rows[i].Cells[0].Value;
                if (titleItem != null && titleItem.Equals(cinema))
                    return true;
            }
            return false;
        }

        private bool EditRowGrid(DataGridView cinema, out int rowIndex, out WatchItem? cinemaItem)
        {
            rowIndex = -1;
            cinemaItem = null;

            if (cinema.SelectedRows.Count == 0)
            {
                MessageBoxProvider.ShowWarning("Highlight the desired line");
                return false;
            }

            rowIndex = cinema.CurrentCell.RowIndex;
            cinemaItem = GetItem(cinema, rowIndex);

            return true;
        }

        private WatchItem GetItem(DataGridView cinema, int rowIndex)
        {
            if (cinema.Rows[rowIndex].Cells[3].Value.ToString() != string.Empty)
            {
                var strDateWatch = cinema.Rows[rowIndex].Cells[3].Value.ToString();
                var dateWatch = DateTime.Parse(strDateWatch);
                var grade = decimal.Parse(cinema.Rows[rowIndex].Cells[4].Value.ToString());

                WatchItem cinemaItem = new WatchItem(
                                                   cinema.Rows[rowIndex].Cells[0].Value.ToString(),
                                                   decimal.Parse(cinema.Rows[rowIndex].Cells[1].Value.ToString()),
                                                   dateWatch,
                                                   grade,
                                                   TypeCinema.Unknown);
                return cinemaItem;
            }
            else
            {
                WatchItem cinemaItem = new WatchItem(
                                                  cinema.Rows[rowIndex].Cells[0].Value.ToString(),
                                                  decimal.Parse(cinema.Rows[rowIndex].Cells[1].Value.ToString()),
                                                  TypeCinema.Unknown);
                return cinemaItem;
            }
        }

        private int NumberItemGridCinema(DataGridView cinema, string titleCinema)
        {
            foreach (DataGridViewRow row in cinema.Rows)
            {
                if (row.Cells[0].Value.ToString() == titleCinema)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void ReplacementEditItem(DataGridView cinema, WatchItem cinemaItem, int rowItem)
        {
            cinema.Rows[rowItem].Cells[0].Value = cinemaItem.Name;
            cinema.Rows[rowItem].Cells[1].Value = cinemaItem.NumberSequel;
            if (cinemaItem.Detail?.DateWatch != null)
            {
                cinema.Rows[rowItem].Cells[2].Value = "+";
                cinema.Rows[rowItem].Cells[3].Value = cinemaItem.Detail?.DateWatch?.ToString("dd.MM.yyyy");
                cinema.Rows[rowItem].Cells[4].Value = cinemaItem.Detail?.Grade;
            }
            else
            {
                cinema.Rows[rowItem].Cells[2].Value = "-";
                cinema.Rows[rowItem].Cells[3].Value = string.Empty;
                cinema.Rows[rowItem].Cells[4].Value = string.Empty;
            }
        }
    }
}