using WatchList.WPF.ViewModel;

namespace WatchList.WPF.Views.Message
{
    /// <summary>
    /// Interaction logic for DataReplaceMessageWindow.xaml
    /// </summary>
    public partial class DataReplaceMessageWindow
    {
        public DataReplaceMessageWindow(DataReplaceMessageVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
