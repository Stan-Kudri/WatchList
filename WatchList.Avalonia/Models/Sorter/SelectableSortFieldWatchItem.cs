using CommunityToolkit.Mvvm.ComponentModel;
using Eremex.AvaloniaUI.Controls.Common;
using WatchList.Core.Model.Sortable;

namespace WatchList.Avalonia.Models.Sorter
{
    public partial class SelectableSortFieldWatchItem : ViewModelBase
    {
        [ObservableProperty] private bool _isSelected;

        public SortFieldWatchItem SortField { get; }

        public SelectableSortFieldWatchItem(SortFieldWatchItem sortField) => SortField = sortField;
    }
}
