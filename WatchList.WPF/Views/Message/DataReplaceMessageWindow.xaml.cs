using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.ViewModel;

namespace WatchList.WPF.Views.Message
{
    /// <summary>
    /// Interaction logic for DataReplaceMessageWindow.xaml
    /// </summary>
    public partial class DataReplaceMessageWindow
    {
        public DataReplaceMessageWindow(string titleName, DialogReplaceQuestionManager replaceQuestionManager)
        {
            InitializeComponent();
            DataContext = new DataReplaceMessageViewModel(titleName, replaceQuestionManager);
        }
    }
}
