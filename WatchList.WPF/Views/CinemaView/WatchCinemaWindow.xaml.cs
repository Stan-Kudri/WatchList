using System.Windows;
using WatchList.WPF.ViewModel.ItemsView;

namespace WatchList.WPF.Views.CinemaView
{
    /// <summary>
    /// Interaction logic for AddCinemaWindow.xaml
    /// </summary>
    public partial class WatchCinemaWindow : Window
    {
        public WatchCinemaWindow(CinemaViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
