using MaterialSkin.Controls;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelDataLoadingAlgorithm;
using WatchList.WinForms.Message;

namespace WatchList.WinForms.ChildForms
{
    public partial class DataLoadingAlgorithm : MaterialForm
    {
        private readonly IMessageBox _messageBox;

        public DataLoadingAlgorithm()
        {
            _messageBox = new MessageBoxShow();
            InitializeComponent();
            SetupDefaultValues();
        }

        public ModelLoadData GetLoadData()
        {
            var isDeleteGrade = cbExistGrade.Checked;
            return new ModelLoadData(isDeleteGrade);
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
