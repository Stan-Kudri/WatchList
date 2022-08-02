namespace ListWatchedMoviesAndSeries
{
    public partial class TVSeriesForm : Form
    {
        private BoxCinemaForm box;

        public TVSeriesForm(BoxCinemaForm formBoxCinema)
        {
            box = formBoxCinema;
            InitializeComponent();
        }

        private void btnAddSeries_Click(object sender, EventArgs e)
        {
            if (txtAddSeries.Text.Length <= 0)
                MessageBox.Show("Enter series name");

            else if (txtAddNumberSeason.Text.Length <= 0)
                MessageBox.Show("Enter namber season");

            else
            {
                box.SetNameSeries($"{txtAddSeries.Text} - {txtAddNumberSeason.Text} Season");
                txtAddSeries.Text = string.Empty;
                txtAddNumberSeason.Text = string.Empty;
            }
        }

        private void btnClearTxtSeries_Click(object sender, EventArgs e)
        {
            txtAddNumberSeason.Text = string.Empty;
            txtAddSeries.Text = string.Empty;
        }

        private void btnBackFormSeries_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumberSason(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;
        }
    }
}
