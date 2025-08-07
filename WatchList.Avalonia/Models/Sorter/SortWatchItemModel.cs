using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.Avalonia.Models.Sorter
{
    public partial class SortWatchItemModel : SortItemsModel<WatchItem>
    {
        [ObservableProperty] private List<SelectSortFieldWatchItem> _sortFieldWatchItems = [.. SortFieldWatchItem.List.Select(item => new SelectSortFieldWatchItem(item))];

        public SortWatchItemModel()
            : base(new SortWatchItem() { SortFields = new ObservableCollection<SortFieldWatchItem>() { SortFieldWatchItem.Title } })
        {
        }

        public SortWatchItem GetSortItem() => new() { SortFields = SortFields };

        public void SetSortFields() => SortFields = new ObservableCollection<SortFieldWatchItem>(SortFieldWatchItems.Where(e => e.IsSelected).Select(e => e.SortField));

        public override void Clear()
            => SortFields = new ObservableCollection<SortFieldWatchItem>() { SortFieldWatchItem.Title };

        public string GetSelectItems => SortFieldWatchItems.Where(e => e.IsSelected).Select(e => e.SortField != SortFieldWatchItem.Title).Any()
                                                ? string.Join(", ", SortFieldWatchItems.Where(e => e.IsSelected).Select(e => e.SortField.Name))
                                                : SortFieldWatchItem.Title.ToString();
    }
}
