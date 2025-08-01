using CommunityToolkit.Mvvm.ComponentModel;
using Eremex.AvaloniaUI.Controls.Common;
using WatchList.Core.Model.Sortable;

namespace WatchList.Avalonia.Models.Sorter
{
    public partial class SelectSortFieldWatchItem : ViewModelBase
    {
        [ObservableProperty] private bool _isSelected;

        public SortFieldWatchItem SortField { get; }

        public SelectSortFieldWatchItem(SortFieldWatchItem sortField) => SortField = sortField;
    }
}
