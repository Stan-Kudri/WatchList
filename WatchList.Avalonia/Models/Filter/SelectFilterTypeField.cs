using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.Avalonia.ViewModels;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Avalonia.Models.Filter
{
    public partial class SelectFilterTypeField : ViewModelBase
    {
        [ObservableProperty] private bool _isSelected;

        public TypeCinema TypeField { get; }

        public SelectFilterTypeField(TypeCinema typeField)
        {
            TypeField = typeField;
            IsSelected = true;
        }
    }
}
