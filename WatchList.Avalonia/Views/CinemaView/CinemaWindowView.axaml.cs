using System;
using System.Reactive.Linq;
using Avalonia.ReactiveUI;
using ReactiveUI;
using WatchList.Avalonia.ViewModels.ItemsView;

namespace WatchList.Avalonia.CinemaView;

public partial class CinemaWindowView : ReactiveWindow<CinemaViewModel>
{
    public CinemaWindowView(CinemaViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
        CanResize = false;
        this.WhenActivated(action => action(ViewModel!.SaveCinemaCommand.Subscribe(e =>
        {
            if (e is not null)
            {
                Close(e);
            }
        })));
    }
}
