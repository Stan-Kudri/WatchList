using MaterialSkin.Controls;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelDataLoad;
using WatchList.WinForms.Message;

namespace WatchList.WinForms.ChildForms
{
    /// <summary>
    /// Form class for selecting data upload.
    /// </summary>
    public partial class DownloadDataProcessForm : MaterialForm
    {
        private readonly IMessageBox _messageBox;

        public DownloadDataProcessForm()
        {
            _messageBox = new MessageBoxShow();
            InitializeComponent();
            SetupDefaultValues();
        }

        public ModelProcessUploadData GetLoadData()
        {
            var isDeleteGrade = cbExistGrade.Checked;
            return new ModelProcessUploadData(isDeleteGrade);
        }

        private void BtnClear_Click(object sender, EventArgs e) => SetupDefaultValues();

        private void SetupDefaultValues()
        {
            cbExistGrade.Checked = false;
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
    }
}
