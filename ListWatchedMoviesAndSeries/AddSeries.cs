using ListWatchedMoviesAndSeries.Models.View;

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

            else if (checkValueData == true && numericSeason.Value == 0)
                MessageBox.Show("Grade movie above in  zero", "Indication");

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
            numericGradeSeries.Enabled = true;
        }

        private void DefoultValue()
        {
            txtAddSeries.Text = string.Empty;
            checkValueData = false;
            numericGradeSeries.Enabled = false;
            numericGradeSeries.Value = 0;
            numericGradeSeries.ReadOnly = true;
        }
    }
}
