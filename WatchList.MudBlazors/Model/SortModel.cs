using System.Collections.ObjectModel;
using WatchList.Core.Model.Sorting;

namespace WatchList.MudBlazors.Model
{
    public class SortModel
    {
        public ObservableCollection<WatchItemSortField> Items { get; set; } = new ObservableCollection<WatchItemSortField>(WatchItemSortField.List);

        public WatchItemSortField Type { get; set; } = WatchItemSortField.Title;

        public WatchItemSortField GetSortItem() => Type;

        public void Clear() => Type = WatchItemSortField.Title;
    }
}
