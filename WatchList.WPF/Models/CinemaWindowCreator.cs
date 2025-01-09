using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Model.ItemCinema;
using WatchList.WPF.ViewModel.ItemsView;
using WatchList.WPF.Views.CinemaView;

namespace WatchList.WPF.Models
{
    public class CinemaWindowCreator
    {
        private readonly IServiceProvider _serviceProvider;

        public CinemaWindowCreator(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public WatchCinemaWindow AddItemWindow()
        {
            var viewModel = _serviceProvider.GetRequiredService<AddCinemaViewModel>();
            viewModel.InitializeDefaultValue();
            return new WatchCinemaWindow(viewModel);
        }

        public WatchCinemaWindow EditItemWindow(WatchItem selectItem)
        {
            var viewModel = _serviceProvider.GetRequiredService<EditCinemaViewModel>();
            viewModel.InitializeDefaultValue(selectItem);
            return new WatchCinemaWindow(viewModel);
        }
    }
}
