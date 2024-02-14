using System.Collections.ObjectModel;
using WatchList.Core.Model.Sorting;

namespace WatchList.MudBlazors.Model
{
    public class SortModel
    {
        public ObservableCollection<SortField> Items { get; set; } = new ObservableCollection<SortField>(SortField.List);

        public SortField Type { get; set; } = SortField.Title;

        public SortField GetSortItem() => Type;

        public void Clear() => Type = SortField.Title;
    }
}
