using System.ComponentModel;
using WatchList.WinForms.Control.CheckComboBox.Component;

namespace TestTask.Controls.CheckComboBox
{
    /// <summary>
    /// https://github.com/sgissinger/CheckBoxComboBox/blob/master/CheckBoxComboBox/CheckBoxComboBox.cs.
    /// </summary>
    public partial class CheckBoxComboBox : PopupComboBox
    {
        /// <summary>
        /// TODO: Documentation Member.
        /// </summary>
        private CheckBoxProperties _checkBoxProperties;

        /// <summary>
        /// In DataBinding operations, this property will be used as the DisplayMember in the CheckBoxComboBoxListBox.
        /// The normal/existing "DisplayMember" property is used by the TextBox of the ComboBox to display
        /// a concatenated Text of the items selected. This concatenation and its formatting however is controlled
        /// by the Binded object, since it owns that property.
        /// </summary>
        private string? _displayMemberSingleItem = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxComboBox"/> class.
        /// TODO: Documentation Constructor.
        /// </summary>
        public CheckBoxComboBox()
            : base()
        {
            InitializeComponent();

            _checkBoxProperties = new CheckBoxProperties();
            _checkBoxProperties.PropertyChanged += new EventHandler(CheckBoxProperties_Changed);

            // Dumps the ListControl in a(nother) Container to ensure the ScrollBar on the ListControl does not
            // Paint over the Size grip. Setting the Padding or Margin on the Popup or host control does
            // not work as I expected. I don't think it can work that way.
            CheckBoxCMBListControlContainer containerControl = new CheckBoxCMBListControlContainer();
            CheckComboBoxListControl = new CheckBoxComboBoxListControl(this);
            CheckComboBoxListControl.Items.CheckBoxCheckedChanged += new EventHandler(Items_CheckBoxChanged);
            containerControl.Controls.Add(CheckComboBoxListControl);

            // This padding spaces neatly on the left-hand side and allows space for the size grip at the bottom.
            containerControl.Padding = new Padding(4, 0, 0, 14);

            // The ListControl FILLS the ListContainer.
            CheckComboBoxListControl.Dock = DockStyle.Fill;

            // The DropDownControl used by the base class. Will be wrapped in a popup by the base class.
            DropDownControl = containerControl;

            // Must be set after the DropDownControl is set, since the popup is recreated.
            // NOTE: I made the dropDown protected so that it can be accessible here. It was private.
            _dropDown.Resizable = true;
        }

        /// <summary>
        /// TODO: Documentation Event.
        /// </summary>
        public event EventHandler CheckBoxCheckedChanged;

        /// <summary>
        /// Gets a direct reference to the Items of CheckBoxComboBoxListControl.
        /// You can use it to Get or Set the Checked status of items manually if you want.
        /// But do not manipulate the List itself directly, e.g. Adding and Removing,
        /// since the list is synchronised when shown with the ComboBox.Items. So for changing
        /// the list contents, use Items instead.
        /// </summary>
        /// <returns>Get CheckBoxComboBoxItemList.</returns>
        [Obsolete]
        public CheckBoxComboBoxItemList CheckBoxItems
        {
            get
            {
                // Added to ensure the CheckBoxItems are ALWAYS available for modification via code.
                if (CheckComboBoxListControl.Items.Count != Items.Count)
                {
                    CheckComboBoxListControl.SynchroniseControlsWithComboBoxItems();
                }

                return CheckComboBoxListControl.Items;
            }
        }

        /// <summary>
        /// Gets or sets the DataSource of the combobox. Refreshes the CheckBox wrappers when this is set.
        /// </summary>
        [Obsolete]
        public new object DataSource
        {
            get => base.DataSource;
            set
            {
                base.DataSource = value;

                // This ensures that at least the checkboxitems are available to be initialised.
                if (!string.IsNullOrEmpty(ValueMember))
                {
                    CheckComboBoxListControl.SynchroniseControlsWithComboBoxItems();
                }
            }
        }

        /// <summary>
        /// Gets or sets the ValueMember of the combobox. Refreshes the CheckBox wrappers when this is set.
        /// </summary>
        [Obsolete]
        public new string ValueMember
        {
            get => base.ValueMember;
            set
            {
                base.ValueMember = value;

                // This ensures that at least the checkboxitems are available to be initialised.
                if (!string.IsNullOrEmpty(ValueMember))
                {
                    CheckComboBoxListControl.SynchroniseControlsWithComboBoxItems();
                }
            }
        }

        /// <summary>
        /// Gets or sets in DataBinding operations, this property will be used as the DisplayMember in the CheckBoxComboBoxListBox.
        /// The normal/existing "DisplayMember" property is used by the TextBox of the ComboBox to display
        /// a concatenated Text of the items selected. This concatenation however is controlled by the Binded
        /// object, since it owns that property.
        /// </summary>
        public string DisplayMemberSingleItem
        {
            get
            {
                return string.IsNullOrEmpty(_displayMemberSingleItem)
                    ? DisplayMember
                    : _displayMemberSingleItem;
            }
            set => _displayMemberSingleItem = value;
        }

        /// <summary>
        /// Gets or sets tODO: Documentation Property.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(", ")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TextSeparator { get; set; } = ", ";

        /// <summary>
        /// Gets or sets the properties that will be assigned to the checkboxes as default values.
        /// </summary>
        [Description("The properties that will be assigned to the checkboxes as default values.")]
        [Browsable(true)]
        public CheckBoxProperties CheckBoxProperties
        {
            get => _checkBoxProperties;
            set
            {
                _checkBoxProperties = value;
                CheckBoxProperties_Changed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets made this property Browsable again, since the Base Popup hides it. This class uses it again.
        /// Gets an object representing the collection of the items contained in this
        /// System.Windows.Forms.ComboBox.
        /// </summary>
        /// <returns>A System.Windows.Forms.ComboBox.ObjectCollection representing the items in
        /// the System.Windows.Forms.ComboBox.
        /// </returns>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ObjectCollection Items => base.Items;

        internal CheckBoxComboBoxListControl CheckComboBoxListControl { get; set; }

        internal bool MustAddHiddenItem { get; set; } = false;

        /// <summary>
        /// A function to clear/reset the list.
        /// (Ubiklou : http://www.codeproject.com/KB/combobox/extending_combobox.aspx?msg=2526813#xx2526813xx).
        /// </summary>
        public void Clear()
        {
            Items.Clear();

            if (DropDownStyle == ComboBoxStyle.DropDownList && DataSource == null)
            {
                MustAddHiddenItem = true;
            }
        }

        /// <summary>
        /// Uncheck all items.
        /// </summary>
        public void ClearSelection()
        {
            foreach (CheckBoxComboBoxItem item in CheckBoxItems)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                }
            }
        }

        /// <summary>
        /// Check all items.
        /// </summary>
        /// <param name="selectItems">Check items in ComboBox.</param>
        [Obsolete]
        public void SelectItemsStr(string[] selectItems)
        {
            ClearSelection();
            foreach (CheckBoxComboBoxItem item in CheckBoxItems)
            {
                if (selectItems.Contains(item.Text))
                {
                    item.Checked = true;
                }
            }
        }

        /// <summary>
        /// Check all items.
        /// </summary>
        [Obsolete]
        public void SelectAllItem()
        {
            foreach (CheckBoxComboBoxItem item in CheckBoxItems)
            {
                item.Checked = true;
            }
        }

        /// <summary>
        /// Builds a CSV string of the items selected.
        /// </summary>
        /// <param name="skipFirstItem">Skip first item.</param>
        /// <returns>Get CSVText.</returns>
        internal string GetCSVText(bool skipFirstItem)
        {
            string listText = string.Empty;

            int startIndex = DropDownStyle == ComboBoxStyle.DropDownList
                                                        && DataSource == null
                                                        && skipFirstItem ? 1 : 0;

            for (int index = startIndex; index <= CheckComboBoxListControl.Items.Count - 1; index++)
            {
                CheckBoxComboBoxItem item = CheckComboBoxListControl.Items[index];

                if (item.Checked)
                {
                    listText += string.IsNullOrEmpty(listText) ? item.Text : string.Format("{0}{1}", TextSeparator, item.Text);
                }
            }

            return listText;
        }

        /// <summary>
        /// TODO: Documentation WndProc.
        /// </summary>
        /// <param name="message">Message.</param>
        protected override void WndProc(ref Message message)
        {
            // 323 : Item Added
            // 331 : Clearing
            if (DropDownStyle == ComboBoxStyle.DropDownList
                && DataSource == null
                && message.Msg == 331)
            {
                MustAddHiddenItem = true;
            }

            base.WndProc(ref message);
        }

        /// <summary>
        /// TODO: Documentation OnCheckBoxCheckedChanged.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event.</param>
        protected virtual void OnCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            var listText = GetCSVText(true);

            // The DropDownList style seems to require that the text
            // part of the "textbox" should match a single item.
            if (DropDownStyle != ComboBoxStyle.DropDownList)
            {
                Text = listText;
            }

            // This refreshes the Text of the first item (which is not visible)
            else if (DataSource == null)
            {
                Items[0] = listText;

                // Keep the hidden item and first checkbox item in
                // sync in order to ensure the Synchronise process can match the items.
                CheckBoxItems[0].ComboBoxItem = listText;
            }

            if (CheckBoxCheckedChanged != null)
            {
                CheckBoxCheckedChanged(sender, e);
            }
        }

        /// <summary>
        /// Will add an invisible item when the style is DropDownList,
        /// to help maintain the correct text in main TextBox.
        /// </summary>
        /// <param name="e">Event.</param>
        protected override void OnDropDownStyleChanged(EventArgs e)
        {
            base.OnDropDownStyleChanged(e);

            if (DropDownStyle == ComboBoxStyle.DropDownList
                && DataSource == null
                && !DesignMode)
            {
                MustAddHiddenItem = true;
            }
        }

        /// <summary>
        /// When the ComboBox is resized, the width of the dropdown
        /// is also resized to match the width of the ComboBox. I think it looks better.
        /// </summary>
        /// <param name="e">Event.</param>
        protected override void OnResize(EventArgs e)
        {
            _dropDown.Size = new Size(Width, DropDownControl.Height);

            base.OnResize(e);
        }

        /// <summary>
        /// TODO: Documentation Items_CheckBoxCheckedChanged.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event.</param>
        private void Items_CheckBoxChanged(object sender, EventArgs e) => OnCheckBoxCheckedChanged(sender, e);

        /// <summary>
        /// TODO: Documentation _CheckBoxProperties_PropertyChanged.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event.</param>
        [Obsolete]
        private void CheckBoxProperties_Changed(object sender, EventArgs e)
        {
            foreach (CheckBoxComboBoxItem item in CheckBoxItems)
            {
                item.ApplyProperties(CheckBoxProperties);
            }
        }
    }
}
