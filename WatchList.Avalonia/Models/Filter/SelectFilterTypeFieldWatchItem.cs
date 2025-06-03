using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Avalonia.ViewModels;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Avalonia.Models.Filter
{
    public partial class SelectFilterTypeFieldWatchItem : ViewModelBase
    {
        [ObservableProperty] private bool _isSelected;

        public TypeCinema TypeField { get; }

        public SelectFilterTypeFieldWatchItem(TypeCinema typeField)
        {
            TypeField = typeField;
            IsSelected = true;
        }
    }
}
