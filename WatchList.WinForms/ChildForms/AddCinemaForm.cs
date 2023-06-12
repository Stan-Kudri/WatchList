using MaterialSkin.Controls;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.WinForms.BindingItem.ModelAddAndEditForm;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.ChildForms.Extension;
using WatchList.WinForms.Message;

namespace WatchList.WinForms
{
    /// <summary>
    /// This class Form performs an function Add Cinema item.
    /// </summary>
    public partial class AddCinemaForm : MaterialForm
    {
        private StatusCinema _status = StatusCinema.Planned;

        public AddCinemaForm()
        {
            InitializeComponent();
        }

        private TypeCinema SelectedTypeCinema => (TypeCinema)cmbTypeCinema.SelectedValue;

        private StatusCinema SelectedStatusCinema => (StatusCinema)cmbStatusCinema.SelectedValue;

        public CinemaModel GetCinema()
        {
            var grade = (decimal?)null;

            if (numericGradeCinema.Enabled)
            {
                grade = numericGradeCinema.Value;
            }

            DateTime? dateViewed = dateTimePickerCinema.Enabled == true ? dateTimePickerCinema.Value : null;
            return CinemaModel.CreateNonPlanned(txtAddCinema.Text, numericSeaquel.Value, dateViewed, grade, _status, SelectedTypeCinema);
        }

        private void BtnAddCinema_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out var errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
                DialogResult = DialogResult.TryAgain;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnClearTxtCinema_Click(object sender, EventArgs e) => SetDefaultValues();

        private void SetDefaultValues()
        {
            txtAddCinema.Text = string.Empty;
            numericGradeCinema.Enabled = false;
            numericGradeCinema.Value = 1;
            numericSeaquel.Value = 1;
            numericGradeCinema.ReadOnly = true;
            cmbTypeCinema.SelectedItem = TypeCinema.Movie;
            cmbStatusCinema.SelectedItem = StatusCinema.Planned;
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtAddCinema.Text.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} title";
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

        private void AddCinemaForm_Load(object sender, EventArgs e)
        {
            typeModelBindingSource.DataSource = new SelectableTypeCinemaModel();
            statusModelBindingSource.DataSource = new SelectableStatusCinemaModel();
            dateTimePickerCinema.MaxDate = DateTime.Now;
            cmbTypeCinema.SelectedItem = TypeCinema.Movie;
            cmbStatusCinema.SelectedItem = StatusCinema.Planned;
        }

        private void CmbTypeCinema_Changed(object sender, EventArgs e)
        {
            var type = SelectedTypeCinema;
            labelNumberSequel.Text = type.TypeSequel;
            Text = "Add " + type.Name;
        }

        private void CmbStatusCinema_Changed(object sender, EventArgs e)
        {
            _status = SelectedStatusCinema;
            dateTimePickerCinema.Enabled = _status.HasDateWatch();
            numericGradeCinema.Enabled = _status.HasGradeCinema();
        }
    }
}
