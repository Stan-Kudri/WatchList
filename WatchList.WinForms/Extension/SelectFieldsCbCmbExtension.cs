using System.Collections.ObjectModel;
using Ardalis.SmartEnum;
using TestTask.Controls.CheckComboBox;
using WatchList.WinForms.BindingItem.ModelBoxForm.Sorter;

namespace WatchList.WinForms.Extension
{
    public static class SelectFieldsCbCmbExtension
    {
        [Obsolete]
        public static ObservableCollection<T> SelectFieldCheckBoxCMB<T>(this CheckBoxComboBox checkBoxCMB)
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

            return new ObservableCollection<T>(selectField);
        }

        public static string[] GetSortFieldArray(this SortWatchItemModel sortField)
            => sortField.SortFields.Select(e => e.ToString()).ToArray();
    }
}
