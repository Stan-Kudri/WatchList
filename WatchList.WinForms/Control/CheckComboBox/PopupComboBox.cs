using System.ComponentModel;
using WatchList.WinForms.Control.CheckComboBox.Component;

namespace TestTask.Controls.CheckComboBox
{
    /// <summary>
    /// PopupComboBox.
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    [ToolboxItem(true)]
    [ToolboxItemFilter("System.Windows.Forms")]
    [Description("Displays an editable text box with a drop-down list of permitted values.")]
    public partial class PopupComboBox : ComboBox
    {
        /// <summary>
        /// The pop-up wrapper for the dropDownControl.
        /// Made PROTECTED instead of PRIVATE so descendent classes can set its Resizable property.
        /// Note however the pop-up properties must be set after the dropDownControl is assigned, since this
        /// popup wrapper is recreated when the dropDownControl is assigned.
        /// </summary>
        protected Popup _dropDown = new Popup(new CheckBoxCMBListControlContainer());

        private Control dropDownControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="PopupComboBox"/> class.
        /// </summary>
        public PopupComboBox()
        {
            InitializeComponent();
            base.DropDownHeight = base.DropDownWidth = 1;
            base.IntegralHeight = false;
        }

        /// <summary>Gets or sets this property is not relevant for this class.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int DropDownWidth { get; set; }

        /// <summary>Gets or sets this property is not relevant for this class.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int DropDownHeight
        {
            get => base.DropDownHeight;
            set
            {
                _dropDown.Height = value;
                base.DropDownHeight = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether this property is not relevant for this class.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool IntegralHeight
        {
            get => base.IntegralHeight;
            set => base.IntegralHeight = value;
        }

        /// <summary>Gets this property is not relevant for this class.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ObjectCollection Items
        {
            get => base.Items;
        }

        /// <summary>Gets or sets this property is not relevant for this class.</summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int ItemHeight
        {
            get => base.ItemHeight;
            set => base.ItemHeight = value;
        }

        /// <summary>
        /// Gets or sets the drop down control.
        /// </summary>
        /// <value>The drop down control.</value>
        public Control DropDownControl
        {
            get
            {
                return dropDownControl;
            }

            set
            {
                if (dropDownControl == value)
                {
                    return;
                }

                dropDownControl = value;
                _dropDown = new Popup(value);
            }
        }

        /// <summary>
        /// Shows the drop down.
        /// </summary>
        public void ShowDropDown() => _dropDown?.Show(this);

        /// <summary>
        /// Hides the drop down.
        /// </summary>
        public void HideDropDown() => _dropDown?.Hide();

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (NativeMethods.WM_REFLECT + NativeMethods.WM_COMMAND)
                && NativeMethods.HIWORD(m.WParam) == NativeMethods.CBN_DROPDOWN)
            {
                var localDropDown = _dropDown;
                if (localDropDown == null)
                {
                    return;
                }

                // Blocks a redisplay when the user closes the control by clicking
                // on the combobox.
                BeginInvoke(new MethodInvoker(() =>
                {
                    TimeSpan timeSpan = DateTime.Now.Subtract(localDropDown._lastClosedTimeStamp);

                    if (timeSpan.TotalMilliseconds > 100)
                    {
                        ShowDropDown();
                    }
                }));
                return;
            }

            base.WndProc(ref m);
        }
    }
}
