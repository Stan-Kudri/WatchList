namespace ListWatchedMoviesAndSeries
{
    public partial class Movie : Form
    {
        private BoxCinema box;

        public Movie(BoxCinema formBoxCinema)
        {
            box = formBoxCinema;
            InitializeComponent();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            if (txtAddMovie.Text.Length <= 0)
                MessageBox.Show("Enter movie name");

            else
            {
                box.SetNameCinema(txtAddMovie.Text);
                txtAddMovie.Text = string.Empty;
            }

        }

        private void btnClearTxtMovie_Click(object sender, EventArgs e)
        {
            txtAddMovie.Text = string.Empty;
        }

        private void btnBackFormMovie_Click(object sender, EventArgs e)
        {
            box.Show();
            Close();
        }
    }
}
