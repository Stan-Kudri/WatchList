using System.Windows;
using WatchList.Core.Service.Component;
using WatchList.WPF.WindowBox;

namespace WatchList.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CinemaWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageBox _messageBox;

        public CinemaWindow(IServiceProvider serviceProvider, IMessageBox messageBox)
        {
            _serviceProvider = serviceProvider;
            _messageBox = messageBox;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mergeDBWindow = new MergeDatabaseWindow(_messageBox);
            mergeDBWindow.Show();
            /*

            using OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".db"; // Required file extension 
            fileDialog.Filter = "Text documents (.db)|*.db"; // Optional file extensions

            fileDialog.ShowDialog();

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
            */
        }
    }
}
