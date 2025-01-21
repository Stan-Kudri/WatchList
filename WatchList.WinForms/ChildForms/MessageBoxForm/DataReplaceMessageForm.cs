using System.ComponentModel;
using WatchList.Core.Enums;

namespace WatchList.WinForms.ChildForms.MessageBoxForm
{
    /// <summary>
    /// A form class with a choice of custom buttons for action when asked.
    /// </summary>
    public partial class DataReplaceMessageForm : Form
    {
        public DataReplaceMessageForm(string titleItem)
        {
            InitializeComponent();
            labelTitleItem.Text = $"Title: {titleItem}";
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        private void Btn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ResultQuestion = QuestionResultEnum.No;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
