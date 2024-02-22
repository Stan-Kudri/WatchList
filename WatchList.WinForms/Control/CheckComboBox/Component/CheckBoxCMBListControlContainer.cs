using System.ComponentModel;
using TestTask.Controls.CheckComboBox;

namespace WatchList.WinForms.Control.CheckComboBox.Component
{
    /// <summary>
    /// A container control for the ListControl to ensure the ScrollBar on the ListControl does not
    /// Paint over the Size grip. Setting the Padding or Margin on the Popup or host control does
    /// not work as I expected.
    /// </summary>
    [ToolboxItem(false)]
    public class CheckBoxCMBListControlContainer : UserControl
    {
        public CheckBoxCMBListControlContainer()
            : base()
        {
            BackColor = SystemColors.Window;
            BorderStyle = BorderStyle.FixedSingle;
            AutoScaleMode = AutoScaleMode.Inherit;
            ResizeRedraw = true;

            // If you don't set this, then resize operations cause an error in the base class.
            MinimumSize = new Size(1, 1);
            MaximumSize = new Size(500, 500);
        }

        /// <summary>
        /// Prescribed by the Popup class to ensure Resize operations work correctly.
        /// </summary>
        /// <param name="m">WndProc.</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if ((Parent as Popup).ProcessResizing(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }
    }
}
