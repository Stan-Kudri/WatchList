using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Model.ItemCinema;
using WatchList.WPF.ViewModel.ItemsView;
using WatchList.WPF.Views.CinemaView;

namespace WatchList.WPF.Models
{
    public class CinemaWindowCreator(IServiceProvider serviceProvider)
    {
        public WatchCinemaWindow AddItemWindow()
        {
            var viewModel = serviceProvider.GetRequiredService<AddCinemaViewModel>();
            viewModel.InitializeDefaultValue();
            return new WatchCinemaWindow(viewModel);
        }

        public WatchCinemaWindow EditItemWindow(WatchItem selectItem)
        {
            var viewModel = serviceProvider.GetRequiredService<EditCinemaViewModel>();
            viewModel.InitializeDefaultValue(selectItem);
            return new WatchCinemaWindow(viewModel);
        }
    }
}
