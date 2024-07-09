using MaterialSkin.Controls;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelAddAndEditForm;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.ChildForms.Extension;
using WatchList.WinForms.Exceptions;

namespace WatchList.WinForms.ChildForms
{
    /// <summary>
    /// This class Form performs an function Add Cinema item.
    /// </summary>
    public partial class AddCinemaForm : MaterialForm
    {
        private readonly IMessageBox _messageBox;

        private StatusCinema _status = StatusCinema.Planned;

        public AddCinemaForm(IMessageBox messageBox)
        {
            _messageBox = messageBox;
            InitializeComponent();
        }

        private TypeCinema SelectedTypeCinema
            => cmbTypeCinema.SelectedValue != null
            ? (TypeCinema)cmbTypeCinema.SelectedValue
            : throw new ExceptionSelectValueInComboBox("Wrong combo box format. The format was expected TypeCinema");

        private StatusCinema SelectedStatusCinema
            => cmbStatusCinema.SelectedValue != null
            ? (StatusCinema)cmbStatusCinema.SelectedValue
            : throw new ExceptionSelectValueInComboBox("Wrong combo box format. The format was expected StatusCinema");

        public CinemaModel GetCinema()
        {
            decimal? grade = numericGradeCinema.Enabled == true ? numericGradeCinema.Value : null;
            DateTime? dateViewed = dateTimePickerCinema.Enabled == true ? dateTimePickerCinema.Value : null;

            return CinemaModel.CreateNonPlanned(txtAddCinema.Text, numericSequel.Value, dateViewed, grade, _status, SelectedTypeCinema);
        }

        private async void BtnAddCinema_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out var errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
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
            numericSequel.Value = 1;
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
            else if (numericSequel.Value == 0)
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
