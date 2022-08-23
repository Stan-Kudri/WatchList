using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.EditorForm
{
    public partial class EditorItemCinemaForm : Form
    {
        public const string WatchCinema = "+";
        public const string NotWatchCinema = "-";

        private bool _valueDateChanget;
        private BoxCinemaForm _box;
        private readonly WatchItem _cinema;
        private readonly string _sequel;

        private readonly int _numberRowCinema;
        private readonly int _numberRowAllCinema;

        private bool CheckСhanges
        {
            get
            {
                if (_cinema.Name != txtEditName.Text)
                {
                    return true;
                }
                else if (_cinema.NumberSequel != numericEditSequel.Value)
                {
                    return true;
                }
                else if (_cinema.Detail != null)
                {
                    if (_cinema.Detail.DateWatch != dateTPCinema.Value)
                    {
                        return true;
                    }
                    else if (_cinema.Detail.Grade != numericEditGradeCinema.Value.ToString())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public EditorItemCinemaForm(BoxCinemaForm formBoxCinema, WatchItem? cinema, int numberRowCinema, int numberRowAllCinema)
        {
            _box = formBoxCinema;

            _cinema = cinema;
            _sequel = cinema.GetTypeSequel();
            _numberRowCinema = numberRowCinema;
            _numberRowAllCinema = numberRowAllCinema;

            InitializeComponent();
            DefoultCinemaItem();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (txtEditName.Text.Length <= 0)
            {
                MessageBoxProvider.ShowWarning("Enter movie name");
            }
            if (numericEditSequel.Value == 0)
            {
                MessageBoxProvider.ShowWarning($"Enter namber {_sequel}");
            }
            if (_valueDateChanget == true || _cinema.Detail.DateWatch != null)
            {
                if (numericEditGradeCinema.Value == 0)
                {
                    MessageBoxProvider.ShowWarning("Grade movie above in  zero");
                }
                else if (CheckСhanges)
                {
                    if (MessageBoxProvider.ShowQuestion("Save edit item Cinema?"))
                    {
                        var itemWatch = new WatchItem(txtEditName.Text, numericEditSequel.Value, dateTPCinema.Value, numericEditGradeCinema.Value, _cinema.Type);
                        _box.EditItemGrid(itemWatch, _numberRowCinema, _numberRowAllCinema);

                        Close();
                    }
                }
            }
        }

        private void btnReturnDataCinema_Click(object sender, EventArgs e) => DefoultCinemaItem();

        private void btnCloseEdit_Click(object sender, EventArgs e) => Close();

        private void DefoultCinemaItem()
        {
            txtEditName.Text = _cinema.Name;
            labelNumberSequel.Text = _cinema.GetTypeSequel();
            if (_cinema.GetView() == WatchCinema)
            {
                this.dateTPCinema.Value = _cinema.Detail.DateWatch.Value;
                if (decimal.TryParse(_cinema.Detail.Grade, out decimal value))
                    this.numericEditGradeCinema.Value = value;
            }
            numericEditSequel.Value = _cinema.NumberSequel.Value;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _valueDateChanget = true;
            numericEditGradeCinema.ReadOnly = false;
            numericEditGradeCinema.Enabled = true;
        }
    }
}
