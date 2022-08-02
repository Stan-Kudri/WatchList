namespace ListWatchedMoviesAndSeries
{
    public partial class BoxCinemaForm : Form
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
                    ItemListBox(listCinemaBoxName, out var movie);
                }
                else if (page == tabSeriesPage)
                {
                    ItemListBox(listSeriesBoxName, out var series);
                }
                else if (page == tabAllCinemaPage)
                {
                    ItemListBox(listAllBoxName, out var cinema);
                    RemoveElement(cinema);
                }
            }
        }

        private void ItemListBox(ListBox box, out string cinema)
        {
            if (box.SelectedItems.Count < 0)
                cinema = string.Empty;
            else
            {
                cinema = box.Text;
                box.Items.Remove(cinema);
                if (box != listAllBoxName)
                {
                    listAllBoxName.Items.Remove(cinema);
                }
            }
        }

        private void RemoveElement(string cinema)
        {
            if (listCinemaBoxName.Items.Contains(cinema))
                listCinemaBoxName.Items.Remove(cinema);
            else
                listSeriesBoxName.Items.Remove(cinema);
        }
    }
}