using Avalonia.Controls;
using WatchList.Avalonia.ViewModel;

namespace WatchList.Avalonia;

public partial class MergeDatabaseWindow : Window
{
    public MergeDatabaseWindow(MergeDatabaseViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
        CanResize = false;
    }
}
