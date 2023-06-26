using WatchList.Core.Model.QuestionResult;

namespace WatchList.WinForms.ChildForms.MessageBoxForm
{
    /// <summary>
    /// A form class with a choice of custom buttons for action when asked.
    /// </summary>
    public partial class QuestionMessageBoxForm : Form
    {
        public QuestionMessageBoxForm(string titleItem)
        {
            InitializeComponent();
            labelTitleItem.Text = $"{titleItem}";
        }

        public QuestionResultEnum ResultQuestion { get; private set; }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            ResultQuestion = QuestionResultEnum.Yes;
            DialogResult = DialogResult.OK;
        }

        private void BtnAllYes_Click(object sender, EventArgs e)
        {
            ResultQuestion = QuestionResultEnum.AllYes;
            DialogResult = DialogResult.OK;
        }

        private void BtnAllNo_Click(object sender, EventArgs e)
        {
            ResultQuestion = QuestionResultEnum.AllNo;
            DialogResult = DialogResult.OK;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            ResultQuestion = QuestionResultEnum.No;
            DialogResult = DialogResult.OK;
        }
    }
}