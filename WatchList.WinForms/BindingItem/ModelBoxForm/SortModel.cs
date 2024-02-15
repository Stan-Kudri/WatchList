using System.Collections.ObjectModel;
using WatchList.Core.Model.Sorting;

namespace WatchList.WinForms.BindingItem.ModelBoxForm
{
    public class SortModel : ModelBase
    {
        private WatchItemSortField _type = WatchItemSortField.Title;

        public ObservableCollection<WatchItemSortField> Items { get; set; } = new ObservableCollection<WatchItemSortField>(WatchItemSortField.List);

        public WatchItemSortField Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }

        public WatchItemSortField GetSortItem() => Type;
    }
}
