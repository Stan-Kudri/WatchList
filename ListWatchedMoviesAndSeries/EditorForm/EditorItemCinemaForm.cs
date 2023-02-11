using Core.Model.Item;
using ListWatchedMoviesAndSeries.BindingItem.Model;
using ListWatchedMoviesAndSeries.BindingItem.ModelAddAndEditForm;
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

        public EditorItemCinemaForm(BoxCinemaForm formBoxCinema, CinemaModel cinema, int numberRowCinema)
        {
            _cinema = cinema ?? throw new ArgumentException("Item cinema not null", nameof(cinema));
            _box = formBoxCinema;
            _numberRowCinema = numberRowCinema;

            InitializeComponent();
        }

        private TypeCinema SelectedTypeCinema
        {
            get => (TypeCinema)cmbTypeCinema.SelectedValue;
        }

        private void SetupDefaultValues(CinemaModel cinema)
        {
            if (cinema.NumberSequel == 0)
            {
                throw new Exception("Number sequel number greater than zero");
            }

            txtEditName.Text = cinema.Name;
            numericEditSequel.Value = Convert.ToDecimal(cinema.NumberSequel);
            cmbTypeCinema.SelectedItem = cinema.Type;

            if (!cinema.HasWatchDate())
            {
                return;
            }

            numericEditGradeCinema.Enabled = true;
            dateTPCinema.Value = cinema.Date.Value;

            if (decimal.TryParse(cinema.Grade.ToString(), out decimal value))
            {
                numericEditGradeCinema.Value = value;
            }
        }

        private StatusCinema GetCurrentStatus()
        {
            return numericEditGradeCinema.Enabled ? StatusCinema.Watch : StatusCinema.NotWatch;
        }

        private void SaveEditionElement()
        {
            var cinemaModel = GetCurrentCinemaModel();
            _box.EditItemGrid(cinemaModel, _numberRowCinema);
        }

        private CinemaModel GetCurrentCinemaModel()
        {
            var type = SelectedTypeCinema;
            var id = _cinema.Id;
            var status = GetCurrentStatus();
            if (status == StatusCinema.Watch)
            {
                return new CinemaModel(txtEditName.Text, numericEditSequel.Value, dateTPCinema.Value, numericEditGradeCinema.Value, status, type, id);
            }

            return new CinemaModel(txtEditName.Text, numericEditSequel.Value, null, null, status, type, id);
        }

        private bool ValidateFields(out string errorMessage)
        {
            if (txtEditName.Text.Length <= 0)
            {
                errorMessage = $"Enter {SelectedTypeCinema.Name} name";
                return false;
            }
            else if (numericEditSequel.Value == 0)
            {
                errorMessage = $"Enter number {SelectedTypeCinema.Name}";
                return false;
            }
            else if (numericEditGradeCinema.Enabled && _cinema?.Date == null)
            {
                if (numericEditGradeCinema.Value == 0)
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
            var currentWatchItem = GetCurrentCinemaModel().ToWatchItem();
            var oldWatchItem = _cinema.ToWatchItem();
            return !oldWatchItem.Equals(currentWatchItem);
        }

        private void EditorItemCinemaForm_Load(object sender, EventArgs e)
        {
            typeModelBindingSource.DataSource = new SelectableTypeCinemaModel();
            dateTPCinema.MaxDate = DateTime.Now;
            SetupDefaultValues(_cinema);
        }

        private void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateFields(out string errorMessage))
            {
                MessageBoxProvider.ShowWarning(errorMessage);
                return;
            }

            if (HasChanges() && MessageBoxProvider.ShowQuestion("Save edit item Cinema?"))
            {
                SaveEditionElement();
            }

            Close();
        }

        private void BtnReturnDataCinema_Click(object sender, EventArgs e)
        {
            SetupDefaultValues(_cinema);
        }

        private void DateTimePick_ValueChanged(object sender, EventArgs e)
        {
            numericEditGradeCinema.ReadOnly = false;
            numericEditGradeCinema.Enabled = true;
        }

        private void CmbTypeCinemaChanged(object sender, EventArgs e)
        {
            var type = SelectedTypeCinema;
            labelNumberSequel.Text = type.TypeSequel;
        }
    }
}
