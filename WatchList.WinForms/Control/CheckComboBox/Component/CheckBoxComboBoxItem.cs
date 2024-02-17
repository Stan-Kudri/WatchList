using System.ComponentModel;
using TestTask.Controls.CheckComboBox;

namespace WatchList.WinForms.Control.CheckComboBox.Component
{
    /// <summary>
    /// The CheckBox items displayed in the Popup of the ComboBox.
    /// </summary>
    [ToolboxItem(false)]
    public class CheckBoxComboBoxItem : CheckBox
    {
        /// <summary>
        /// A reference to the CheckBoxComboBox.
        /// </summary>
        private readonly CheckBoxComboBox _checkBoxComboBox;

        /// <summary>
        /// A reference to the Item in ComboBox.Items that this object is extending.
        /// </summary>
        private object _comboBoxItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxComboBoxItem"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="owner">A reference to the CheckBoxComboBox.</param>
        /// <param name="comboBoxItem">A reference to the item in the ComboBox.Items that this object is extending.</param>
        public CheckBoxComboBoxItem(
            CheckBoxComboBox owner, object comboBoxItem)
            : base()
        {
            DoubleBuffered = true;
            _checkBoxComboBox = owner;
            _comboBoxItem = comboBoxItem;

            if (_checkBoxComboBox.DataSource != null)
            {
                AddBindings();
            }
            else
            {
                Text = comboBoxItem.ToString();
            }
        }

        /// <summary>
        /// Gets a reference to the Item in ComboBox.Items that this object is extending.
        /// </summary>
        public object ComboBoxItem
        {
            get => _comboBoxItem;
            internal set => _comboBoxItem = value;
        }

        /// <summary>
        /// When using Data Binding operations via the DataSource property of the ComboBox. This
        /// adds the required Bindings for the CheckBoxes.
        /// </summary>
        public void AddBindings()
        {
            // Note, the text uses "DisplayMemberSingleItem", not "DisplayMember" (unless its not assigned)
            DataBindings.Add("Text", _comboBoxItem, _checkBoxComboBox.DisplayMemberSingleItem);

            // The ValueMember must be a bool type property usable by the CheckBox.Checked.
            // This helps to maintain proper selection state in the Binded object,
            // even when the controls are added and removed.
            DataBindings.Add(
                             "Checked",
                             _comboBoxItem,
                             _checkBoxComboBox.ValueMember,
                             false,
                             DataSourceUpdateMode.OnPropertyChanged,
                             false,
                             null,
                             null);

            // Helps to maintain the Checked status of this
            // checkbox before the control is visible
            if (_comboBoxItem is INotifyPropertyChanged)
            {
                ((INotifyPropertyChanged)_comboBoxItem).PropertyChanged += new PropertyChangedEventHandler(CheckBoxCMBItem_PropertyChanged);
            }
        }

        internal void ApplyProperties(CheckBoxProperties properties)
        {
            Appearance = properties.Appearance;
            AutoCheck = properties.AutoCheck;
            AutoEllipsis = properties.AutoEllipsis;
            AutoSize = properties.AutoSize;
            CheckAlign = properties.CheckAlign;
            FlatAppearance.BorderColor = properties.FlatAppearanceBorderColor;
            FlatAppearance.BorderSize = properties.FlatAppearanceBorderSize;
            FlatAppearance.CheckedBackColor = properties.FlatAppearanceCheckedBackColor;
            FlatAppearance.MouseDownBackColor = properties.FlatAppearanceMouseDownBackColor;
            FlatAppearance.MouseOverBackColor = properties.FlatAppearanceMouseOverBackColor;
            FlatStyle = properties.FlatStyle;
            ForeColor = properties.ForeColor;
            RightToLeft = properties.RightToLeft;
            TextAlign = properties.TextAlign;
            ThreeState = properties.ThreeState;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            // Found that when this event is raised, the bool value of the binded item is not yet updated.
            if (_checkBoxComboBox.DataSource != null)
            {
                var pI = ComboBoxItem.GetType().GetProperty(_checkBoxComboBox.ValueMember);
                pI.SetValue(ComboBoxItem, Checked, null);
            }

            base.OnCheckedChanged(e);

            // Forces a refresh of the Text displayed in the main TextBox of the ComboBox,
            // since that Text will most probably represent a concatenation of selected values.
            // Also see DisplayMemberSingleItem on the CheckBoxComboBox for more information.
            if (_checkBoxComboBox.DataSource != null)
            {
                var oldDisplayMember = _checkBoxComboBox.DisplayMember;
                _checkBoxComboBox.DisplayMember = null;
                _checkBoxComboBox.DisplayMember = oldDisplayMember;
            }
        }

        /// <summary>
        /// Added this handler because the control doesn't seem
        /// to initialize correctly until shown for the first
        /// time, which also means the summary text value
        /// of the combo is out of sync initially.
        /// </summary>
        private void CheckBoxCMBItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _checkBoxComboBox.ValueMember)
            {
                Checked = (bool)_comboBoxItem
                                    .GetType()
                                    .GetProperty(_checkBoxComboBox.ValueMember)
                                    .GetValue(_comboBoxItem, null);
            }
        }
    }
}
