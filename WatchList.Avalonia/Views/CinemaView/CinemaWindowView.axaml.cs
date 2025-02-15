using System;
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
        this.WhenActivated(action => action(ViewModel!.CloseWindowCommand.Subscribe(e => Close(e))));
        this.WhenActivated(action => action(ViewModel!.SaveCinemaCommand.Subscribe(e => Close(e))));
    }
}
