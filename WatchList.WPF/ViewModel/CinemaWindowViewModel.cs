using System.Windows.Controls;
using DevExpress.Mvvm;
using WatchList.WPF.Data;
using WatchList.WPF.Views;

namespace WatchList.WPF.ViewModel
{
    public sealed class CinemaWindowViewModel : BindableBase
    {
        private Page? _currentPage;

        public CinemaWindowViewModel(PageService pageService)
        {
            pageService.PageChanged += (o, page) => CurrentPage = page;
            pageService.Open(this, new CinemaPage());
        }

        public Page? CurrentPage { get => _currentPage; set => SetValue(ref _currentPage, value); }
    }
}
