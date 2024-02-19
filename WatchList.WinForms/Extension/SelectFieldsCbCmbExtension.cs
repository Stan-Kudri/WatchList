using Ardalis.SmartEnum;
using TestTask.Controls.CheckComboBox;

namespace WatchList.WinForms.Extension
{
    public static class SelectFieldsCbCmbExtension
    {
        public static HashSet<T> SelectFieldFilter<T>(this CheckBoxComboBox checkBoxCMB)
            where T : SmartEnum<T>
        {
            var selectField = new HashSet<T>();

            foreach (string item in checkBoxCMB.Items)
            {
                var checkBoxItem = checkBoxCMB.CheckBoxItems[item];

                if (checkBoxItem.Checked && SmartEnum<T>.TryFromName(item, out var sortField))
                {
                    selectField.Add(sortField);
                }
            }

            return selectField;
        }
    }
}
