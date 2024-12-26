using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Model.Filter;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WPF.Data;
using WatchList.WPF.Models;
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
                                      .AddScoped<WatchItemCreator>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<DownloadDataService>()
                                      .AddScoped<PageModel>()
                                      .AddScoped<SortWatchItemModel>()
                                      .AddScoped<TypeSortFields>()
                                      .AddScoped<IFilterItem, FilterItemModel>()
                                      .AddSingleton<PageService>()
                                      .AddScoped<ViewModelLocator>()
                                      .AddScoped<FileLoaderDB>()
                                      .AddLogging();

        public static IServiceCollection AppServicePageContainer(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<CinemaWindow>()
                                .AddTransient<MergeDatabaseWindow>();
    }
}
