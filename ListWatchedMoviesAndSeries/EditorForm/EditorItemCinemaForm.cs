using Core.Model.Item;
using ListWatchedMoviesAndSeries.BindingItem.Model;
using ListWatchedMoviesAndSeries.Models.Item;
using MaterialSkin.Controls;

namespace ListWatchedMoviesAndSeries.EditorForm
{
    /// <summary>
    /// This class Form performs an function Edit Cinema item.
    /// </summary>
    public partial class EditorItemCinemaForm : MaterialForm
    {
        private readonly BoxCinemaForm _box;
        private readonly CinemaModel _cinema;
        private readonly int _numberRowCinema;

        private StatusCinema _status = StatusCinema.AllStatus;

        public EditorItemCinemaForm(BoxCinemaForm formBoxCinema, CinemaModel cinema, int numberRowCinema)
        {
            if (cinema == null)
            {
                throw new ArgumentException("Item cinema not null", nameof(cinema));
            }

            _cinema = cinema;
            _box = formBoxCinema;
            _numberRowCinema = numberRowCinema;
            InitializeComponent();
            SetupDefaultValues();
        }

        private string Type => _cinema?.Type?.Name ?? string.Empty;

        private void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out string errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
            }
            else if (HasChanges())
            {
                if (MessageBoxProvider.ShowQuestion("Save edit item Cinema?"))
                {
                    SaveEditionElement();
                    Close();
                }
            }
        }

        private void BtnReturnDataCinema_Click(object sender, EventArgs e) => SetupDefaultValues();

        private void BtnCloseEdit_Click(object sender, EventArgs e) => Close();

        private void SetupDefaultValues()
        {
            txtEditName.Text = _cinema.Name;
            labelNumberSequel.Text = _cinema.Type.Name;
            dateTPCinema.MaxDate = DateTime.Now;
            if (_cinema.HasWatchDate())
            {
                numericEditGradeCinema.Enabled = true;
                dateTPCinema.Value = _cinema.Date.Value;
                if (decimal.TryParse(_cinema.Grade, out decimal value))
                {
                    numericEditGradeCinema.Value = value;
                }
            }

            if (_cinema.NumberSequel != null)
            {
                numericEditSequel.Value = Convert.ToDecimal(_cinema.NumberSequel);
            }
        }

        private void DateTimePick_ValueChanged(object sender, EventArgs e)
        {
            numericEditGradeCinema.ReadOnly = false;
            numericEditGradeCinema.Enabled = true;
        }

        private void SaveEditionElement()
        {
            var type = _cinema.Type ?? TypeCinema.AllType;
            var id = _cinema.Id;
            _status = numericEditGradeCinema.Enabled ? StatusCinema.Watch : StatusCinema.NotWatch;
            if (numericEditGradeCinema.Enabled)
            {
                var itemWatch = new CinemaModel(txtEditName.Text, numericEditSequel.Value, dateTPCinema.Value, numericEditGradeCinema.Value, _status, type, id);
                _box.EditItemGrid(itemWatch, _numberRowCinema);
            }
            else
            {
                var itemWatch = new CinemaModel(txtEditName.Text, numericEditSequel.Value, null, null, _status, type, id);
                _box.EditItemGrid(itemWatch, _numberRowCinema);
            }
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtEditName.Text.Length <= 0)
            {
                errorMessage = $"Enter {Type} name";
                return false;
            }
            else if (numericEditSequel.Value == 0)
            {
                errorMessage = $"Enter number {Type}";
                return false;
            }
            else if (numericEditGradeCinema.Enabled && _cinema?.Date == null)
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
            {
                return true;
            }

            if (_cinema.Status == StatusCinema.AllStatus)
            {
                return false;
            }

            return _cinema.Date != dateTPCinema.Value
                || _cinema.Grade != numericEditGradeCinema.Value.ToString();
        }
    }
}
