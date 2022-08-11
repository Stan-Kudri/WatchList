using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
    {
        public void SetNameCinema(Cinema move)
        {
            if (move != null)
            {
                if (move.Name != null)
                {
                    AddCinemaGridRow(dgvMove, move);
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
                    RemoveRowGrid(dgvMove);
                if (page == tabSeriesPage)
                    RemoveRowGrid(dgvSeries);
                /*
                if (page == tabAllCinemaPage)
                    RemoveRowGrid(dgvCinema);
                */
            }
        }

        private void RemoveRowGrid(DataGridView dataGridCinema)
        {
            if (dataGridCinema.SelectedRows.Count == 0)
            {
                MessageBox.Show("Highlight the desired line", "Information");
                return;
            }

            for (var index = dataGridCinema.SelectedRows.Count - 1; index > -1; index--)
            {
                var grdUsersSelectedRow = dataGridCinema.SelectedRows[index];
                dataGridCinema.Rows.Remove(grdUsersSelectedRow);
            }
        }

        private void AddCinemaGridRow(DataGridView dataGridCinema, Cinema cinema)
        {
            string? partOrSeason = SeasonOrEmpty(cinema);
            if (cinema.Date != null)
            {
                DateTime date = (DateTime)cinema.Date;
                dataGridCinema.Rows.Add(cinema.Name, partOrSeason, cinema.View, date.ToString("dd.MM.yyyy"), cinema.Grade.ToString());
            }
            else
            {
                dataGridCinema.Rows.Add(cinema.Name, partOrSeason, cinema.View, string.Empty, string.Empty);
            }
        }

        private string? SeasonOrEmpty(Cinema cinema) => cinema.Part == null ? string.Empty : cinema.Part.ToString();
    }
}