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
    /// This class Form performs an function Edit Cinema item.
    /// </summary>
    public partial class EditorItemCinemaForm : MaterialForm
    {
        private readonly CinemaModel _cinema;
        private readonly IMessageBox _messageBox;

        public EditorItemCinemaForm(CinemaModel cinema, IMessageBox messageBox)
        {
            _cinema = cinema ?? throw new ArgumentNullException("Item cinema not null", nameof(cinema));
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

        public CinemaModel GetEditItemCinema()
        {
            var type = SelectedTypeCinema;
            var id = _cinema.Id;
            var status = SelectedStatusCinema;
            decimal? grade = numericGradeCinema.Enabled ? numericGradeCinema.Value : null;
            var date = status == StatusCinema.Viewed ? dateTimePickerCinema.Value : (DateTime?)null;

            return CinemaModel.CreateNonPlanned(txtEditName.Text, numericEditSequel.Value, date, grade, status, type, id);
        }

        private async void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out string errorMessage))
            {
                await _messageBox.ShowWarning(errorMessage);
                DialogResult = DialogResult.TryAgain;
            }
            else
            {
                if (HasChanges() && await _messageBox.ShowQuestion("Save edit item Cinema?"))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    await _messageBox.ShowInfo("No changed item cinema.");
                    Close();
                }
            }
        }

        private void BtnReturnDataCinema_Click(object sender, EventArgs e) => SetupDefaultValues(_cinema);

        private void EditorItemCinemaForm_Load(object sender, EventArgs e)
        {
            typeModelBindingSource.DataSource = new SelectableTypeCinemaModel();
            statusModelBindingSource.DataSource = new SelectableStatusCinemaModel();
            dateTimePickerCinema.MaxDate = DateTime.Now;
            SetupDefaultValues(_cinema);
        }

        private void CmbTypeCinema_Changed(object sender, EventArgs e) => labelNumberSequel.Text = SelectedTypeCinema.TypeSequel;

        private void CmbStatusCinema_Changed(object sender, EventArgs e)
        {
            dateTimePickerCinema.Enabled = SelectedStatusCinema.HasDateWatch();
            numericGradeCinema.Enabled = SelectedStatusCinema.HasGradeCinema();
        }

        private void SetupDefaultValues(CinemaModel cinema)
        {
            if (cinema.Sequel == 0)
            {
                throw new ArgumentException("Number sequel number greater than zero", nameof(cinema.Sequel));
            }

            txtEditName.Text = cinema.Title;
            numericEditSequel.Value = Convert.ToDecimal(cinema.Sequel);
            cmbTypeCinema.SelectedItem = cinema.Type;
            cmbStatusCinema.SelectedItem = cinema.Status;

            if (cinema.TryGetWatchDate(out var dateWatch))
            {
                dateTimePickerCinema.Enabled = true;
                dateTimePickerCinema.Value = dateWatch;
            }

            if (cinema.HasGrade())
            {
                numericGradeCinema.Enabled = true;
                numericGradeCinema.Value = cinema.Grade.ToDecimal();
            }
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtEditName.Text.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} title";
                return false;
            }
            else if (numericEditSequel.Value == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (numericGradeCinema.Enabled && _cinema?.Date == null)
            {
                if (numericGradeCinema.Value == 0)
                {
                    errorMessage = $"Grade {SelectedTypeCinema.Name} above in zero";
                    return false;
                }
            }

            errorMessage = string.Empty;
            return true;
        }

        private bool HasChanges()
        {
            var currentWatchItem = GetEditItemCinema().ToWatchItem();
            var oldWatchItem = _cinema.ToWatchItem();
            return !oldWatchItem.Equals(currentWatchItem);
        }
    }
}
