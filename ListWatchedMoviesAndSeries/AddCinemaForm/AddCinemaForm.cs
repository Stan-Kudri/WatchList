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
        private readonly BoxCinemaForm _box;
        private StatusCinema _status = StatusCinema.NotWatch;
        private TypeCinema _type;

        private TypeModel SelectedType { get; set; } = new TypeModel();

        public AddCinemaForm(BoxCinemaForm formBoxCinema)
        {
            InitializeComponent();
            cmbTypeCinema.DataSource = SelectedType.TypesCinema;

            _box = formBoxCinema;
            dateTimePickerCinema.MaxDate = DateTime.Now;
        }

        private void BtnAddCinema_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out var errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
                return;
            }

            if (numericGradeCinema.Enabled)
            {
                _box.AddItemToGrid(new CinemaModel(txtAddCinema.Text, numericSeaquel.Value, dateTimePickerCinema.Value, numericGradeCinema.Value, _status, _type));
            }
            else
            {
                _box.AddItemToGrid(new CinemaModel(txtAddCinema.Text, numericSeaquel.Value, _status, _type));
            }

            SetDefaultValues();
        }

        private void BtnClearTxtCinema_Click(object sender, EventArgs e) => SetDefaultValues();

        private void BtnBackFormCinema_Click(object sender, EventArgs e) => Close();

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
                errorMessage = $"Enter {_type.Name} name";
                return false;
            }
            else if (numericSeaquel.Value == 0)
            {
                errorMessage = $"Enter number {_type.Name}";
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

        private void CmbTypeCinemaChanged(object sender, EventArgs e)
        {
            SelectedType.Type = SelectedType.TypesCinema[cmbTypeCinema.SelectedIndex];
            EditFormByTypeCinema();
        }

        private void EditFormByTypeCinema()
        {
            _type = SelectedType.Type;
            labelNumberSequel.Text = _type.TypeSequel;
            Text = "Add " + _type.Name;
        }
    }
}
