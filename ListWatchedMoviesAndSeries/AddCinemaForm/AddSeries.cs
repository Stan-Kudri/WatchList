using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

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
            {
                MessageBoxProvider.ShowWarning("Enter series name");
            }
            else if (numericSeason.Value == 0)
            {
                MessageBoxProvider.ShowWarning("Enter namber season");
            }
            else if (checkValueData == true && numericGradeSeries.Value == 0)
            {
                MessageBoxProvider.ShowWarning("Grade movie above in  zero");
            }
            else
            {
                if (checkValueData)
                {
                    _box.SetNameGrid(new WatchItem(txtAddSeries.Text, numericSeason.Value, dateTimePickerSeries.Value, numericGradeSeries.Value, TypeCinema.Series));
                }
                else
                {
                    _box.SetNameGrid(new WatchItem(txtAddSeries.Text, numericSeason.Value, TypeCinema.Series));
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
