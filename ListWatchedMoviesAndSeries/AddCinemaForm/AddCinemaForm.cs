using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries
{
    public partial class AddCinemaForm : Form
    {
        private BoxCinemaForm _box;
        private bool checkValueData = false;
        private readonly TypeCinema _type;

        public AddCinemaForm(BoxCinemaForm formBoxCinema, TypeCinema type)
        {
            _box = formBoxCinema;
            _type = type;
            InitializeComponent();
            labelNumberSeaquel.Text = _type == TypeCinema.Movie ? TypeCinema.Movie.Name : TypeCinema.Series.Name;
        }

        private void BtnAddSeries_Click(object sender, EventArgs e)
        {
            if (txtAddCinema.Text.Length <= 0)
            {
                var strType = _type == TypeCinema.Series ? "series" : "movie";
                MessageBoxProvider.ShowWarning($"Enter {strType} name");
            }
            else if (numericSeaquel.Value == 0)
            {
                MessageBoxProvider.ShowWarning($"Enter namber {_type.Name}");
            }
            else if (checkValueData == true && numericGradeCinema.Value == 0)
            {
                MessageBoxProvider.ShowWarning("Grade cinema above in zero");
            }
            else
            {
                if (checkValueData)
                {
                    _box.SetNameGrid(new WatchItem(txtAddCinema.Text, numericSeaquel.Value, dateTimePickerCinema.Value, numericGradeCinema.Value, _type));
                }
                else
                {
                    _box.SetNameGrid(new WatchItem(txtAddCinema.Text, numericSeaquel.Value, _type));
                }

                DefoultValue();
            }
        }

        private void BtnClearTxtSeries_Click(object sender, EventArgs e) => DefoultValue();

        private void BtnBackFormSeries_Click(object sender, EventArgs e) => Close();

        private void DateTimePickerSeries_ValueChanged(object sender, EventArgs e)
        {
            checkValueData = true;
            numericGradeCinema.ReadOnly = false;
            numericGradeCinema.Enabled = true;
        }

        private void DefoultValue()
        {
            txtAddCinema.Text = string.Empty;
            checkValueData = false;
            numericGradeCinema.Enabled = false;
            numericGradeCinema.Value = 0;
            numericGradeCinema.ReadOnly = true;
        }
    }
}
