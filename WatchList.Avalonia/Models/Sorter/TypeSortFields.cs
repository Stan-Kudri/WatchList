using CommunityToolkit.Mvvm.ComponentModel;

namespace WatchList.Avalonia.Models.Sorter
{
    public partial class TypeSortFields : ObservableObject
    {
        private bool _isAscending = false;

        [ObservableProperty] private string _buttonContent = null!;

        public bool IsAscending
        {
            get => _isAscending;
            set
            {
                ButtonContent = _isAscending ? "↑" : "↓";
                SetProperty(ref _isAscending, value);
            }
        }
    }
}
