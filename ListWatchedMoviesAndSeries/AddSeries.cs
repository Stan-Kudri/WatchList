using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries
{
    public partial class TVSeriesForm : Form
    {
        private BoxCinemaForm _box;
        private bool checkValueData = false;

        public TVSeriesForm(BoxCinemaForm formBoxCinema)
        {
            _box = formBoxCinema;
            InitializeComponent();
        }

        private void BtnAddSeries_Click(object sender, EventArgs e)
        {
            if (txtAddSeries.Text.Length <= 0)
                MessageBox.Show("Enter series name", "Indication");

            else if (numericSeason.Value == 0)
                MessageBox.Show("Enter namber season", "Indication");

            else
            {
                if (checkValueData)
                {
                    _box.SetNameSeries(new Series(txtAddSeries.Text, numericSeason.Value, dateTimePickerSeries.Value, numericGradeSeries.Value));
                }
                else
                {
                    _box.SetNameSeries(new Series(txtAddSeries.Text, numericSeason.Value));
                }

                DefoultValue();
            }
        }

        private void BtnClearTxtSeries_Click(object sender, EventArgs e) => DefoultValue();

        private void BtnBackFormSeries_Click(object sender, EventArgs e) => Close();

        private void DateTimePickerSeries_ValueChanged(object sender, EventArgs e)
        {
            checkValueData = true;
            numericGradeSeries.ReadOnly = false;
        }

        private void DefoultValue()
        {
            txtAddSeries.Text = string.Empty;
            checkValueData = false;
            numericGradeSeries.Value = 1;
            numericGradeSeries.ReadOnly = true;
        }
    }
}
