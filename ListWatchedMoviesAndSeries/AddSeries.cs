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

            else if (numericSeason.Value == 0)
                MessageBox.Show("Enter namber season");

            else
            {
                box.SetNameSeries($"{txtAddSeries.Text} - {numericSeason.Text} Season");
                txtAddSeries.Text = string.Empty;
                numericSeason.Value = 0;
            }
        }

        private void btnClearTxtSeries_Click(object sender, EventArgs e)
        {
            numericSeason.Value = 0;
            txtAddSeries.Text = string.Empty;
        }

        private void btnBackFormSeries_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
