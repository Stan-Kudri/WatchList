using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries
{
    public partial class MovieForm : Form
    {
        private BoxCinemaForm _box;
        private bool checkValueData = false;

        public MovieForm(BoxCinemaForm formBoxCinema)
        {
            _box = formBoxCinema;
            InitializeComponent();
        }

        private void BtnAddMovie_Click(object sender, EventArgs e)
        {
            if (txtAddMovie.Text.Length <= 0)
            {
                MessageBoxProvider.ShowWarning("Enter movie name");
            }
            else if (numericPart.Value == 0)
            {
                MessageBoxProvider.ShowWarning("Enter namber part");
            }
            else if (checkValueData == true && numericGradeMovie.Value == 0)
            {
                MessageBoxProvider.ShowWarning("Grade movie above in  zero");
            }
            else
            {
                if (checkValueData)
                {
                    _box.SetNameGrid(new WatchItem(txtAddMovie.Text, numericPart.Value, dateTimePickerMovie.Value, numericGradeMovie.Value, TypeCinema.Movie));
                }
                else
                {
                    _box.SetNameGrid(new WatchItem(txtAddMovie.Text, numericPart.Value, TypeCinema.Movie));
                }

                DefoultValue();
            }
        }

        private void BtnClearTxtMovie_Click(object sender, EventArgs e) => DefoultValue();

        private void BtnBackFormMovie_Click(object sender, EventArgs e) => Close();

        private void DateTimePickerMovie_ValueChanged(object sender, EventArgs e)
        {
            checkValueData = true;
            numericGradeMovie.ReadOnly = false;
            numericGradeMovie.Enabled = true;
        }

        private void DefoultValue()
        {
            txtAddMovie.Text = string.Empty;
            checkValueData = false;
            numericGradeMovie.Enabled = false;
            numericGradeMovie.Value = 0;
            numericGradeMovie.ReadOnly = true;
        }
    }
}
