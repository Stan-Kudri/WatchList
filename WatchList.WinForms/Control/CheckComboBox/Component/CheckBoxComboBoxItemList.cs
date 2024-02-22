using System.ComponentModel;
using TestTask.Controls.CheckComboBox;

namespace WatchList.WinForms.Control.CheckComboBox.Component
{
    /// <summary>
    /// A Typed List of the CheckBox items.
    /// Simply a wrapper for the CheckBoxComboBox.Items. A list of CheckBoxComboBoxItem objects.
    /// This List is automatically synchronised with the Items of the ComboBox and extended to
    /// handle the additional boolean value. That said, do not Add or Remove using this List,
    /// it will be lost or regenerated from the ComboBox.Items.
    /// </summary>
    [ToolboxItem(false)]
    public class CheckBoxComboBoxItemList : List<CheckBoxComboBoxItem>
    {
        private readonly CheckBoxComboBox _checkBoxComboBox;

        public CheckBoxComboBoxItemList(CheckBoxComboBox checkBoxComboBox)
        {
            _checkBoxComboBox = checkBoxComboBox;
        }

        public event EventHandler CheckBoxCheckedChanged;

        /// <summary>
        /// Returns the item with the specified displayName or Text.
        /// </summary>
        /// <param name="displayName">Index.</param>
        /// <return>Item CheckBoxComboBox ин index.</return>
        public CheckBoxComboBoxItem this[string displayName]
        {
            get
            {
                // An invisible item exists in this scenario to help with the Text displayed in the TextBox of the Combo
                // 1 Ubiklou : 2008-04-28 : Ignore first item.
                // (http://www.codeproject.com/KB/combobox/extending_combobox.aspx?fid=476622&df=90&mpp=25&noise=3&sort=Position&view=Quick&select=2526813&fr=1#xx2526813xx)
                var startIndex = _checkBoxComboBox.DropDownStyle
                                    == ComboBoxStyle.DropDownList
                                    && _checkBoxComboBox.DataSource
                                    == null ? 1 : 0;

                for (var index = startIndex; index <= Count - 1; index++)
                {
                    var item = this[index];

                    string? text;

                    if (string.IsNullOrEmpty(item.Text)
                        && item.DataBindings != null
                        && item.DataBindings["Text"] != null)
                    {
                        var propertyInfo = item.ComboBoxItem.GetType()
                                                                     .GetProperty(item.DataBindings["Text"].BindingMemberInfo.BindingMember);
                        text = propertyInfo.GetValue(item.ComboBoxItem, null) as string;
                    }
                    else
                    {
                        text = item.Text;
                    }

                    if (text.CompareTo(displayName) == 0)
                    {
                        return item;
                    }
                }

                throw new ArgumentOutOfRangeException(string.Format("\"{0}\" does not exist in this combo box.", displayName));
            }
        }

        [Obsolete("Do not add items to this list directly. Use the ComboBox items instead.", false)]
        public new void Add(CheckBoxComboBoxItem item)
        {
            item.CheckedChanged += new EventHandler(Item_CheckedChanged);
            base.Add(item);
        }

        public new void AddRange(IEnumerable<CheckBoxComboBoxItem> collection)
        {
            foreach (var item in collection)
            {
                item.CheckedChanged += new EventHandler(Item_CheckedChanged);
            }

            base.AddRange(collection);
        }

        public new void Clear()
        {
            foreach (var item in this)
            {
                item.CheckedChanged -= Item_CheckedChanged;
            }

            base.Clear();
        }

        [Obsolete("Do not remove items from this list directly. Use the ComboBox items instead.", false)]
        public new bool Remove(CheckBoxComboBoxItem item)
        {
            item.CheckedChanged -= Item_CheckedChanged;
            return base.Remove(item);
        }

        protected void OnCheckBoxCheckedChanged(object sender, EventArgs e)
            => CheckBoxCheckedChanged?.Invoke(sender, e);

        private void Item_CheckedChanged(object sender, EventArgs e)
            => OnCheckBoxCheckedChanged(sender, e);
    }
}
