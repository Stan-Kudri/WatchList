using Microsoft.Extensions.DependencyInjection;
using WatchList.WPF.ViewModel;

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

        public DataReplaceMessageViewModel DataReplaceMessageViewModel
            => _provider!.GetRequiredService<DataReplaceMessageViewModel>();

        public static IServiceCollection AddViewModels(ServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<CinemaWindowViewModel>()
                .AddTransient<CinemaPageViewModel>()
                .AddTransient<MergeDatabaseViewModel>()
                .AddTransient<DataReplaceMessageViewModel>();

        public static void Init(ServiceProvider provider) => _provider = provider;
    }
}
