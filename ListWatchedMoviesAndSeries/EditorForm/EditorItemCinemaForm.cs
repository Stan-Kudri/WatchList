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

        private readonly int _numberRowCinema;
        private readonly int _numberRowAllCinema;

        private string getType => _cinema != null ? _cinema?.Type?.Name : string.Empty;

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
            _numberRowCinema = numberRowCinema;
            _numberRowAllCinema = numberRowAllCinema;

            InitializeComponent();
            DefoultCinemaItem();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (ValidateCinemaPaddingFields(out string errorMessage) == false)
            {
                MessageBoxProvider.ShowWarning(errorMessage);
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

        private void btnReturnDataCinema_Click(object sender, EventArgs e) => DefoultCinemaItem();

        private void btnCloseEdit_Click(object sender, EventArgs e) => Close();

        private void DefoultCinemaItem()
        {
            txtEditName.Text = _cinema.Name;
            labelNumberSequel.Text = _cinema.GetTypeSequel();
            if (_cinema.GetView() == WatchCinema)
            {
                dateTPCinema.Value = _cinema.Detail.DateWatch.Value;
                if (decimal.TryParse(_cinema.Detail.Grade, out decimal value))
                    numericEditGradeCinema.Value = value;
            }
            numericEditSequel.Value = _cinema.NumberSequel.Value;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _valueDateChanget = true;
            numericEditGradeCinema.ReadOnly = false;
            numericEditGradeCinema.Enabled = true;
        }

        private bool ValidateCinemaPaddingFields(out string errorMessage)
        {
            if (txtEditName.Text.Length <= 0)
            {
                errorMessage = $"Enter {getType} name";
                return false;
            }
            else if (numericEditSequel.Value == 0)
            {
                errorMessage = $"Enter namber {getType}";
                return false;
            }
            else if (_valueDateChanget == true && _cinema?.Detail?.DateWatch == null)
            {
                if (numericEditGradeCinema.Value == 0)
                {
                    errorMessage = $"Grade {getType} above in zero";
                    return false;
                }

            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
