using MaterialSkin.Controls;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelDataLoad;
using WatchList.WinForms.Message;

namespace WatchList.WinForms.ChildForms
{
    /// <summary>
    /// Form class for selecting data upload.
    /// </summary>
    public partial class MergeDatabaseForm : MaterialForm
    {
        private readonly IMessageBox _messageBox;

        public MergeDatabaseForm()
        {
            _messageBox = new MessageBoxShow();
            InitializeComponent();
        }

        private TypeCinema SelectTypeCinema =>
            cmbTypeCinema.SelectedValue != null ? (TypeCinema)cmbTypeCinema.SelectedValue : throw new Exception("Wrong combo box format");

        public ModelProcessUploadData GetLoadData()
        {
            var isDeleteGrade = cbExistGrade.Checked;
            return new ModelProcessUploadData(isDeleteGrade, SelectTypeCinema);
        }

        private void BtnClear_Click(object sender, EventArgs e) => SetupDefaultValues();

        private void SetupDefaultValues()
        {
            cbExistGrade.Checked = false;
            cmbTypeCinema.SelectedItem = TypeCinema.AllType;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (_messageBox.ShowQuestion("Add data from a file using the following algorithm?"))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                return;
            }
        }

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            typeUploadBindingSource.DataSource = new ModelTypeCinemaUpload();
            cmbTypeCinema.SelectedItem = TypeCinema.AllType;
            cbExistGrade.Checked = false;
        }
    }
}
