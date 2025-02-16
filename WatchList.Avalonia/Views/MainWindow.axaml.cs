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
                action(ViewModel!.ShowAddCinemaDialog.RegisterHandler(DoShowAddIemDialogAsync));
                action(ViewModel!.ShowEditCinemaDialog.RegisterHandler(DoShowEditIemDialogAsync));
            });
        }

        private async Task DoShowAddIemDialogAsync(IInteractionContext<AddCinemaViewModel, bool> interaction)
        {
            var dialog = new CinemaWindowView(interaction.Input);
            var result = await dialog.ShowDialog<bool>(this);
            interaction.SetOutput(result);
        }

        private async Task DoShowEditIemDialogAsync(IInteractionContext<EditCinemaViewModel, bool> interaction)
        {
            var dialog = new CinemaWindowView(interaction.Input);
            var result = await dialog.ShowDialog<bool>(this);
            interaction.SetOutput(result);
        }
    }
}
