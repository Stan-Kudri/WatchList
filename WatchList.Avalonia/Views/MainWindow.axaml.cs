using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using WatchList.Avalonia.CinemaView;
using WatchList.Avalonia.ViewModels;
using WatchList.Avalonia.ViewModels.ItemsView;

namespace WatchList.Avalonia.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Design.IsDesignMode)
            {
                return;
            }

            this.WhenActivated(action =>
            {
                action(ViewModel!.ShowAddCinemaDialog.RegisterHandler(DoShowDialogAsync));
            });
        }

        private async Task DoShowDialogAsync(IInteractionContext<AddCinemaViewModel, bool> interaction)
        {
            var dialog = new CinemaWindowView(interaction.Input);
            var result = await dialog.ShowDialog<bool>(this);
            interaction.SetOutput(result);
        }
    }
}
