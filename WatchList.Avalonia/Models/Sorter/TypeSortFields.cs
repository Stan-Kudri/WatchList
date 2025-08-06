using CommunityToolkit.Mvvm.ComponentModel;

namespace WatchList.Avalonia.Models.Sorter
{
    public partial class TypeSortFields : ObservableObject
    {
        private bool _isAscending = false;

        [ObservableProperty] private string _buttonContent = null!;

        public TypeSortFields() => IsAscending = false;

        public bool IsAscending
        {
            get => _isAscending;
            set
            {
                SetProperty(ref _isAscending, value);
                ButtonContent = _isAscending ? "↑" : "↓";
            }
        }
    }
}
