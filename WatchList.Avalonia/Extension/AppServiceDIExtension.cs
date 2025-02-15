using Microsoft.Extensions.DependencyInjection;
using WatchList.Avalonia.Models;
using WatchList.Avalonia.ViewModels;
using WatchList.Avalonia.ViewModels.ItemsView;
using WatchList.Avalonia.Views.Message;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Migrations.SQLite;

namespace WatchList.Avalonia.Extension
{
    public static class AppServiceDIExtension
    {
        public static IServiceCollection AppServiceContainer(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton(new DbContextFactoryMigrator("app.db"))
                                      .AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create())
                                      .AddScoped<WatchItemRepository>()
                                      .AddScoped<IMessageBox, MessageWindow>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<PageModel>()
                                      .AddScoped<WatchItemCreator>()
                                      .AddLogging();

        public static IServiceCollection AppViewModelContainer(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<MainWindowViewModel>()
                                .AddTransient<AddCinemaViewModel>()
                                .AddTransient<EditCinemaViewModel>();
    }
}
