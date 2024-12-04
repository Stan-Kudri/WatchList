using Microsoft.Extensions.DependencyInjection;
using WatchList.WPF.ViewModel;
using WatchList.WPF.ViewModel.ItemsView;

namespace WatchList.WPF.Data
{
    public class ViewModelLocator
    {
        private static ServiceProvider? _provider;

        public CinemaWindowViewModel CinemaWindowViewModel
            => _provider!.GetRequiredService<CinemaWindowViewModel>();

        public CinemaPageViewModel CinemaPageViewModel
            => _provider!.GetRequiredService<CinemaPageViewModel>();

        public MergeDatabaseViewModel MergeDatabaseViewModel
            => _provider!.GetRequiredService<MergeDatabaseViewModel>();

        public DataReplaceMessageVM DataReplaceMessageVM
            => _provider!.GetRequiredService<DataReplaceMessageVM>();
        public AddCinemaViewModel AddCinemaViewModel
            => _provider!.GetRequiredService<AddCinemaViewModel>();

        public static IServiceCollection AddViewModels(ServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<CinemaWindowViewModel>()
                .AddTransient<CinemaPageViewModel>()
                .AddTransient<MergeDatabaseViewModel>()
                .AddTransient<DataReplaceMessageVM>()
                .AddTransient<AddCinemaViewModel>();

        public static void Init(ServiceProvider provider) => _provider = provider;
    }
}
