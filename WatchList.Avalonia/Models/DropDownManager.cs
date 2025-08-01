using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WatchList.Avalonia.Models
{
    public class DropDownManager<T>(Func<string> displayTextGetter) : ObservableObject
    {
        private bool _isOpen;
        private string? _selectedDisplay;

        private readonly Func<string> _displayTextGetter = displayTextGetter
               ?? throw new ArgumentNullException(nameof(displayTextGetter));

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                SetProperty(ref _isOpen, value);
                UpdateDisplay();
            }
        }

        public string SelectedDisplay
        {
            get => _displayTextGetter();
            private set => SetProperty(ref _selectedDisplay, value);
        }

        public void UpdateDisplay()
        {
            SelectedDisplay = _displayTextGetter();
            OnPropertyChanged(nameof(SelectedDisplay));
        }
    }
}
