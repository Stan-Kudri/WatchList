using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.EditorForm
{
    public partial class EditorItemCinemaForm : Form
    {
        public const string WatchCinema = "+";
        public const string NotWatchCinema = "-";

        private bool _checkDataWatch;//Поле для контроля использования DataTimePicker или уже выставленной даты просмотра.
        private BoxCinemaForm _box;
        private readonly WatchItem _cinema;

        private readonly int _numberRowCinema;
        private readonly int _numberRowAllCinema;

        private string Type => _cinema?.Type?.Name ?? string.Empty;

        public EditorItemCinemaForm(BoxCinemaForm formBoxCinema, WatchItem? cinema, int numberRowCinema, int numberRowAllCinema)
        {
            if (cinema == null)
                throw new ArgumentException("Item cinema not null");

            _cinema = cinema;
            _box = formBoxCinema;
            _numberRowCinema = numberRowCinema;
            _numberRowAllCinema = numberRowAllCinema;

            InitializeComponent();
            DefoultCinemaItem();

            dateTPCinema.MaxDate = DateTime.Now;
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateCinemaPaddingFields(out string errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
            }
            else if (HasChanges())
            {
                if (MessageBoxProvider.ShowQuestion("Save edit item Cinema?"))
                {
                    if (_checkDataWatch)
                    {
                        var itemWatch = new WatchItem(txtEditName.Text, numericEditSequel.Value, dateTPCinema.Value, numericEditGradeCinema.Value, _cinema.Type, _cinema.Id.ToString());
                        _box.EditItemGrid(itemWatch, _numberRowCinema, _numberRowAllCinema);
                    }
                    else
                    {
                        var itemWatch = new WatchItem(txtEditName.Text, numericEditSequel.Value, null, null, _cinema.Type, _cinema.Id.ToString());
                        _box.EditItemGrid(itemWatch, _numberRowCinema, _numberRowAllCinema);
                    }
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
                _checkDataWatch = true;
                dateTPCinema.Value = _cinema.Detail.DateWatch.Value;
                if (decimal.TryParse(_cinema.Detail.Grade, out decimal value))
                    numericEditGradeCinema.Value = value;
            }
            numericEditSequel.Value = _cinema.NumberSequel.Value;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            _checkDataWatch = true;
            numericEditGradeCinema.ReadOnly = false;
            numericEditGradeCinema.Enabled = true;
        }

        private bool ValidateCinemaPaddingFields(out string errorMessage)
        {
            if (txtEditName.Text.Length <= 0)
            {
                errorMessage = $"Enter {Type} name";
                return false;
            }
            else if (numericEditSequel.Value == 0)
            {
                errorMessage = $"Enter namber {Type}";
                return false;
            }
            else if (_checkDataWatch && _cinema?.Detail?.DateWatch == null)
            {
                if (numericEditGradeCinema.Value == 0)
                {
                    errorMessage = $"Grade {Type} above in zero";
                    return false;
                }
            }
            errorMessage = string.Empty;
            return true;
        }

        private bool HasChanges()
        {
            if (_cinema.Name != txtEditName.Text || _cinema.NumberSequel != numericEditSequel.Value)
                return true;
            if (_cinema.Detail == null)
                return false;
            return _cinema.Detail.DateWatch != dateTPCinema.Value ||
                    _cinema.Detail.Grade != numericEditGradeCinema.Value.ToString();
        }
    }
}
