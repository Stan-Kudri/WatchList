using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.View;

namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
    {
        public void SetNameMove(Movie move)
        {
            if (move != null)
            {
                if (move.Name != null)
                {
                    AddCinemaGridRow(dgvMove, move);
                    AddCinemaGridRow(dgvCinema, move);
                }
            }
        }

        public void SetNameSeries(Series series)
        {
            if (series != null)
            {
                if (series.Name != null)
                {
                    AddCinemaGridRow(dgvSeries, series);
                    AddCinemaGridRow(dgvCinema, series);
                }
            }
        }

        public BoxCinemaForm()
        {
            InitializeComponent();
        }


        private void btnFormMovie_Click(object sender, EventArgs e)
        {
            using (var form = new MovieForm(this))
            {
                form.ShowDialog();
            }
        }

        private void btnFormSeries_Click(object sender, EventArgs e)
        {
            using (var form = new TVSeriesForm(this))
            {
                form.ShowDialog();
            }
        }

        private void btnDeliteMovie_Click(object sender, EventArgs e)
        {
            if (BoxName.SelectedTab != null)
            {
                var page = BoxName.SelectedTab;

                if (page == tabMovePage)
                {
                    RemoveRowGrid(dgvMove, out string titleItem);
                    RemoveItemRowGrid(dgvCinema, titleItem);
                }
                else if (page == tabSeriesPage)
                {
                    RemoveRowGrid(dgvSeries, out string titleItem);
                    RemoveItemRowGrid(dgvCinema, titleItem);
                }
                else if (page == tabAllCinemaPage)
                {
                    RemoveRowGrid(dgvCinema, out string titleItem);
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

        private void RemoveRowGrid(DataGridView dataGridCinema, out string? name)
        {
            name = string.Empty;

            if (dataGridCinema.SelectedRows.Count == 0)
            {
                MessageBox.Show("Highlight the desired line", "Information");
                return;
            }

            name = SelectedRowCinemaName(dataGridCinema);

            for (var index = dataGridCinema.SelectedRows.Count - 1; index > -1; index--)
            {
                var grdUsersSelectedRow = dataGridCinema.SelectedRows[index];
                dataGridCinema.Rows.Remove(grdUsersSelectedRow);
            }

        }

        private string? SelectedRowCinemaName(DataGridView gridCinema)
        {
            int rowIndex = gridCinema.CurrentCell.RowIndex;
            int columnIndex = 0; //Column "Name" in DataGridView
            return gridCinema.Rows[rowIndex].Cells[columnIndex].Value.ToString();
        }

        private void RemoveItemRowGrid(DataGridView dataGridCinema, string title)
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
            string? partOrSeason = Sequel(cinema);

            string formatDate = cinema.Detail?.DateWatch?.ToString("dd.MM.yyyy") ?? string.Empty;

            dataGridCinema.Rows.Add(cinema.Name, partOrSeason, cinema.GetView(), formatDate, cinema.Detail?.Grade);
        }

        private bool CheckItemGridMove(string cinema)
        {
            foreach (DataGridViewRow row in dgvMove.Rows)
            {
                if (row.Cells["MoveTitle"].Value.Equals(cinema))
                    return true;
            }
            return false;
        }

        private string? Sequel(WatchItem cinema) => cinema != null ? cinema.GetSequel() : string.Empty;
    }
}