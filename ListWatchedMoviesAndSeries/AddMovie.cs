using ListWatchedMoviesAndSeries.Models.View;

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
                MessageBox.Show("Enter movie name", "Indication");

            else if (checkValueData == true && numericGradeMovie.Value == 0)
                MessageBox.Show("Grade movie above in  zero", "Indication");


            else
            {
                if (checkValueData)
                {
                    _box.SetNameMove(new Movie(txtAddMovie.Text, dateTimePickerMovie.Value, numericGradeMovie.Value));
                }
                else
                {
                    _box.SetNameMove(new Movie(txtAddMovie.Text));
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
