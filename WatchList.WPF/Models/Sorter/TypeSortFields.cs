using DevExpress.Mvvm;

namespace WatchList.WPF.Models.Sorter
{
    public class TypeSortFields : BindableBase
    {
        private bool _isAscending = false;
        private string _buttonContent = null!;

        public bool IsAscending
        {
            get => _isAscending;
            set
            {
                ButtonContent = _isAscending ? "↑" : "↓";
                SetValue(ref _isAscending, value);
            }
        }

        public string ButtonContent
        {
            get => _buttonContent;
            set => SetValue(ref _buttonContent, value);
        }
    }
}
