using System.ComponentModel;
using TestTask.Controls.CheckComboBox;

namespace WatchList.WinForms.Control.CheckComboBox.Component
{
    /// <summary>
    /// This ListControl that pops up to the User. It contains the CheckBoxComboBoxItems.
    /// The items are docked DockStyle.Top in this control.
    /// </summary>
    [ToolboxItem(false)]
    public class CheckBoxComboBoxListControl : UserControl
    {
        /// <summary>
        /// Simply a reference to the CheckBoxComboBox.
        /// </summary>
        private readonly CheckBoxComboBox _checkBoxComboBox;

        /// <summary>
        /// A Typed list of ComboBoxCheckBoxItems.
        /// </summary>
        private readonly CheckBoxComboBoxItemList _items;

        public CheckBoxComboBoxListControl(CheckBoxComboBox owner)
            : base()
        {
            DoubleBuffered = true;

            _checkBoxComboBox = owner;
            _items = new CheckBoxComboBoxItemList(_checkBoxComboBox);
            BackColor = SystemColors.Window;

            // AutoScaleMode = AutoScaleMode.Inherit;
            AutoScroll = true;
            ResizeRedraw = true;

            // if you don't set this, a Resize operation causes an error in the base class.
            MinimumSize = new Size(1, 1);
            MaximumSize = new Size(500, 500);
        }

        public CheckBoxComboBoxItemList Items { get => _items; }

        /// <summary>
        /// Maintains the controls displayed in the list by keeping them in sync with the actual
        /// items in the combobox. (e.g. removing and adding as well as ordering).
        /// </summary>
        [Obsolete]
        public void SynchroniseControlsWithComboBoxItems()
        {
            SuspendLayout();

            if (_checkBoxComboBox.MustAddHiddenItem && _checkBoxComboBox.DataSource == null)
            {
                _checkBoxComboBox.Items.Insert(0, _checkBoxComboBox.GetCSVText(false)); // INVISIBLE ITEM
                _checkBoxComboBox.SelectedIndex = 0;
                _checkBoxComboBox.MustAddHiddenItem = false;
            }

            DisposeItemCheckBoxCMB();
            Controls.Clear();

            var newList = new CheckBoxComboBoxItemList(_checkBoxComboBox);

            ChangeItemsByIndex(newList);

            _items.Clear();
            _items.AddRange(newList);

            IsRevertItemCheckBoxCMB(newList);

            // Keep the first item invisible
            if (_checkBoxComboBox.DropDownStyle == ComboBoxStyle.DropDownList
                && _checkBoxComboBox.DataSource == null
                && !DesignMode)
            {
                _checkBoxComboBox.CheckBoxItems[0].Visible = false;
            }

            ResumeLayout();
        }

        /// <summary>
        /// Prescribed by the Popup control to enable Resize operations.
        /// </summary>
        /// <param name="m">Message.</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if ((Parent.Parent as Popup).ProcessResizing(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }

        [Obsolete]
        protected override void OnVisibleChanged(EventArgs e)
        {
            // Synchronises the CheckBox list with the items in the ComboBox.
            SynchroniseControlsWithComboBoxItems();
            base.OnVisibleChanged(e);
        }

        private void DisposeItemCheckBoxCMB()
        {
            for (var index = _items.Count - 1; index >= 0; index--)
            {
                var item = _items[index];
                if (!_checkBoxComboBox.Items.Contains(item.ComboBoxItem))
                {
                    _items.Remove(item);
                    item.Dispose();
                }
            }
        }

        [Obsolete]
        private void ChangeItemsByIndex(CheckBoxComboBoxItemList newList)
        {
            var hasHiddenItem = _checkBoxComboBox.DropDownStyle == ComboBoxStyle.DropDownList
                                    && _checkBoxComboBox.DataSource == null
                                    && !DesignMode;

            var countItems = _checkBoxComboBox.Items.Count;

            for (var index = 0; index < countItems; index++)
            {
                var obj = _checkBoxComboBox.Items[index];
                CheckBoxComboBoxItem? item = null;

                // The hidden item could match any other item when only
                // one other item was selected.
                if (index == 0 && hasHiddenItem && _items.Count > 0)
                {
                    item = _items[0];
                }
                else
                {
                    var startIndex = hasHiddenItem
                        ? 1 // Skip the hidden item, it could match
                        : 0;
                    for (var newIndex = startIndex; newIndex <= _items.Count - 1; newIndex++)
                    {
                        if (_items[newIndex].ComboBoxItem == obj)
                        {
                            item = _items[newIndex];
                            break;
                        }
                    }
                }

                if (item == null)
                {
                    item = new CheckBoxComboBoxItem(_checkBoxComboBox, obj);
                    item.ApplyProperties(_checkBoxComboBox.CheckBoxProperties);
                }

                newList.Add(item);
                item.Dock = DockStyle.Top;
            }
        }

        private void IsRevertItemCheckBoxCMB(CheckBoxComboBoxItemList newList)
        {
            if (newList.Count > 0)
            {
                // This reverse helps to maintain correct docking order.
                newList.Reverse();

                // If you get an error here that "Cannot convert to the desired
                // type, it probably means the controls are not binding correctly.
                // The Checked property is binded to the ValueMember property.
                // It must be a bool for example.
                Controls.AddRange(newList.ToArray());
            }
        }
    }
}
