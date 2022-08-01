namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinema : Form
    {
        public void SetNameCinema(string value)
        {
            if (value != null)
            {
                if (!listAllBoxName.Items.Contains(value) && !listCinemaBoxName.Items.Contains(value))
                {
                    listCinemaBoxName.Items.Add(value);
                    listAllBoxName.Items.Add(value);
                }
            }
        }

        public void SetNameSeries(string value)
        {
            if (value != null)
            {
                if (!listAllBoxName.Items.Contains(value) && !listSeriesBoxName.Items.Contains(value))
                {
                    listSeriesBoxName.Items.Add(value);
                    listAllBoxName.Items.Add(value);
                }
            }
        }

        public BoxCinema()
        {
            InitializeComponent();
        }


        private void btnFormMovie_Click(object sender, EventArgs e)
        {
            Visible = false;
            Movie moveAddForm = new Movie(this);
            moveAddForm.Show();
        }

        private void btnFormSeries_Click(object sender, EventArgs e)
        {
            Visible = false;
            TVSeries moveAddForm = new TVSeries(this);
            moveAddForm.Show();
        }
    }
}