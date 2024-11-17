using System.Windows.Controls;
using WatchList.WPF.Data;
using WatchList.WPF.Views;

namespace WatchList.WPF.ViewModel
{
    public sealed class CinemaWindowViewModel
    {
        public CinemaWindowViewModel(PageService pageService)
        {
            pageService.PageChanged += (o, page) => CurrentPage = page;
            pageService.Open(this, new CinemaPage());
        }

        public Page? CurrentPage { get; private set; }
    }
}
