using Core.Model.Item;
using ListWatchedMoviesAndSeries.BindingItem.Model;
using ListWatchedMoviesAndSeries.BindingItem.ModelAddAndEditForm;
using ListWatchedMoviesAndSeries.Models.Item;
using MaterialSkin.Controls;

namespace ListWatchedMoviesAndSeries
{
    /// <summary>
    /// This class Form performs an function Add Cinema item.
    /// </summary>
    public partial class AddCinemaForm : MaterialForm
    {
        private StatusCinema _status = StatusCinema.NotWatch;

        public AddCinemaForm()
        {
            InitializeComponent();
        }

        private TypeCinema SelectedTypeCinema => (TypeCinema)cmbTypeCinema.SelectedValue;

        public CinemaModel? GetCinema()
        {
            if (!ValidateFields(out var errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
                return null;
            }

            if (numericGradeCinema.Enabled)
            {
                return new CinemaModel(txtAddCinema.Text, numericSeaquel.Value, dateTimePickerCinema.Value, numericGradeCinema.Value, _status, SelectedTypeCinema);
            }
            else
            {
                return new CinemaModel(txtAddCinema.Text, numericSeaquel.Value, _status, SelectedTypeCinema);
            }
        }

        private void BtnClearTxtCinema_Click(object sender, EventArgs e) => SetDefaultValues();

        private void DtpCinema_ValueChanged(object sender, EventArgs e)
        {
            numericGradeCinema.ReadOnly = false;
            numericGradeCinema.Enabled = true;
            _status = StatusCinema.Watch;
        }

        private void SetDefaultValues()
        {
            txtAddCinema.Text = string.Empty;
            numericGradeCinema.Enabled = false;
            numericGradeCinema.Value = 1;
            numericSeaquel.Value = 1;
            numericGradeCinema.ReadOnly = true;
            _status = StatusCinema.NotWatch;
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtAddCinema.Text.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} name";
                return false;
            }
            else if (numericSeaquel.Value == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (numericGradeCinema.Enabled && numericGradeCinema.Value == 0)
            {
                errorMessage = "Grade cinema above in zero";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private void CmbTypeCinema_Changed(object sender, EventArgs e)
        {
            var type = SelectedTypeCinema;
            labelNumberSequel.Text = type.TypeSequel;
            Text = "Add " + type.Name;
        }

        private void AddCinemaForm_Load(object sender, EventArgs e)
        {
            typeModelBindingSource.DataSource = new SelectableTypeCinemaModel();
            dateTimePickerCinema.MaxDate = DateTime.Now;
        }
    }
}
