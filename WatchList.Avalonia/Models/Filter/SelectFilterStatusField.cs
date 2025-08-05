using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Avalonia.ViewModels;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Avalonia.Models.Filter
{
    public partial class SelectFilterStatusField : ViewModelBase
    {
        [ObservableProperty] private bool _isSelected;

        public StatusCinema StatusField { get; }

        public SelectFilterStatusField(StatusCinema statusField)
        {
            StatusField = statusField;
            IsSelected = true;
        }
    }
}
