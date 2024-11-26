using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WPF.Data;
using WatchList.WPF.Models.Filter;
using WatchList.WPF.Models.ModelDataLoad;
using WatchList.WPF.Models.Sorter;
using WatchList.WPF.Views;
using WatchList.WPF.Views.Message;

namespace WatchList.WPF.Extension
{
    public static class AppServiceDIExtension
    {
        public static IServiceCollection AppServiceContainer(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton(new DbContextFactoryMigrator("app.db"))
                                      .AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create())
                                      .AddScoped<WatchItemRepository>()
                                      .AddScoped<IMessageBox, MessageWindow>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<DownloadDataService>()
                                      .AddScoped<SortWatchItemModel>()
                                      .AddScoped<FilterItemModel>()
                                      .AddSingleton<PageService>()
                                      .AddScoped<ViewModelLocator>()
                                      .AddScoped<FiileLoaderDB>()
                                      .AddLogging()
                                      .AddSerilog();

        public static IServiceCollection AppServicePageContainer(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<CinemaWindow>()
                                .AddTransient<MergeDatabaseWindow>();
    }
}
