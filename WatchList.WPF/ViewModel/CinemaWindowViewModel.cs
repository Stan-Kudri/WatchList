using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using WatchList.WPF.Data;
using WatchList.WPF.Views;

namespace WatchList.WPF.ViewModel
{
    [ObservableObject]
    public sealed partial class CinemaWindowViewModel
    {
        [ObservableProperty] private Page? currentPage;

        public CinemaWindowViewModel(PageService pageService)
        {
            pageService.PageChanged += (o, page) => CurrentPage = page;
            pageService.Open(this, new CinemaPage());
        }
    }
}
