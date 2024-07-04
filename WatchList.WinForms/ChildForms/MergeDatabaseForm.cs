using MaterialSkin.Controls;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Service.Component;
using WatchList.WinForms.BindingItem.ModelDataLoad;
using WatchList.WinForms.Exceptions;

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

        private TypeLoadingCinema SelectTypeCinema =>
            cmbTypeCinema.SelectedValue != null ? (TypeLoadingCinema)cmbTypeCinema.SelectedValue : throw new ControlException("Wrong combo box format");

        private Grade SelectGrade =>
            cmbGrade.SelectedValue != null ? (Grade)cmbGrade.SelectedValue : throw new ControlException("Wrong combo box format");

        public ILoadRulesConfig GetLoadRuleConfig()
        {
            var isDeleteGrade = cbExistGrade.Checked;
            var considerDuplicates = cbConsiderDuplicates.Checked;

            if (!considerDuplicates)
            {
                return new LoadRulesConfigModel(isDeleteGrade, new ActionDuplicateItems(), SelectTypeCinema.Value, SelectGrade);
            }

            var listDuplicateLoadRule = clbActionsWithDuplicates.Items.Select(e => new DuplicateLoadingRules(
                e.Tag as DuplicateLoadingRules ?? throw new NullReferenceException("Null reference argument for parameter"),
                checkAction: e.Checked)).ToList();
            return new LoadRulesConfigModel(isDeleteGrade, new ActionDuplicateItems(considerDuplicates, listDuplicateLoadRule), SelectTypeCinema.Value, SelectGrade);
        }

        private void BtnClear_Click(object sender, EventArgs e) => SetupDefaultValues();

        private void SetupDefaultValues()
        {
            cbExistGrade.Checked = false;
            cbConsiderDuplicates.Checked = false;
            cmbTypeCinema.SelectedItem = TypeCinema.Movie;
            cmbGrade.SelectedItem = Grade.AnyGrade;
        }

        private async void BtnOk_Click(object sender, EventArgs e)
        {
            if (await _messageBox.ShowQuestion("Add data from a file using the following algorithm?"))
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
            cmbTypeCinema.SelectedItem = TypeCinema.Movie;
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
