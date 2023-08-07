using MaterialSkin.Controls;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelDataLoad;

namespace WatchList.WinForms.ChildForms
{
    /// <summary>
    /// Form class for selecting data upload.
    /// </summary>
    public partial class MergeDatabaseForm : MaterialForm
    {
        private readonly IMessageBox _messageBox;

        public MergeDatabaseForm(IMessageBox messageBox)
        {
            _messageBox = messageBox;
            InitializeComponent();
        }

        private TypeCinema SelectTypeCinema =>
            cmbTypeCinema.SelectedValue != null ? (TypeCinema)cmbTypeCinema.SelectedValue : throw new Exception("Wrong combo box format");

        private Grade SelectGrade =>
            cmbGrade.SelectedValue != null ? (Grade)cmbGrade.SelectedValue : throw new Exception("Wrong combo box format");

        public ModelProcessUploadData GetLoadData()
        {
            var isDeleteGrade = cbExistGrade.Checked;
            var considerDuplicates = cbConsiderDuplicates.Checked;

            if (!considerDuplicates)
            {
                return new ModelProcessUploadData(isDeleteGrade, new ActionDuplicateItems(), SelectTypeCinema, SelectGrade);
            }

            var listDuplicateLoadRule = clbActionsWithDuplicates.Items.Select(e => new DuplicateLoadingRules(
                e.Tag as DuplicateLoadingRules ?? throw new NullReferenceException("Null reference argument for parameter"),
                checkAction: e.Checked)).ToList();
            return new ModelProcessUploadData(isDeleteGrade, new ActionDuplicateItems(considerDuplicates, listDuplicateLoadRule), SelectTypeCinema, SelectGrade);
        }

        private void BtnClear_Click(object sender, EventArgs e) => SetupDefaultValues();

        private void SetupDefaultValues()
        {
            cbExistGrade.Checked = false;
            cbConsiderDuplicates.Checked = false;
            cmbTypeCinema.SelectedItem = TypeCinema.AllType;
            cmbGrade.SelectedItem = Grade.AnyGrade;
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
            InitializeComboListBox();
            typeUploadBindingSource.DataSource = new ModelTypeCinemaUpload();
            moreGradeBindingSource.DataSource = new ModelDownloadMoreGrade();
            cmbTypeCinema.SelectedItem = TypeCinema.AllType;
            cmbGrade.SelectedItem = Grade.AnyGrade;
            cbExistGrade.Checked = false;
            cbConsiderDuplicates.Checked = false;
        }

        private void CbConsiderDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            var checkedConsiderDuplicate = cbConsiderDuplicates.Checked;
            clbActionsWithDuplicates.Items.ForEach(e => e.Checked = checkedConsiderDuplicate);
            clbActionsWithDuplicates.Enabled = checkedConsiderDuplicate;
        }

        private void InitializeComboListBox()
        {
            foreach (var item in DuplicateLoadingRules.List)
            {
                var checkBox = new MaterialCheckbox();
                checkBox.Text = item.Name;
                checkBox.Tag = item;
                clbActionsWithDuplicates.Items.Add(checkBox);
            }
        }
    }
}
