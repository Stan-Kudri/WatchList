using System.IO;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using WatchList.Core.Extension;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WPF.WindowBox;

namespace WatchList.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Log.Logger = CreateLogger();

            try
            {
                Log.Information("Starting WinForms applications");
                var serviceCollection = AppServiceDI();
                serviceCollection.AddSerilog();

                using var contain = serviceCollection.BuildServiceProvider(
                    new ServiceProviderOptions
                    {
                        ValidateOnBuild = true,
                        ValidateScopes = true,
                    });

                using var scope = contain.CreateScope();
                var serviceProvider = scope.ServiceProvider;

                // Create the startup window
                CinemaWindow cinemaWindow = new CinemaWindow(serviceProvider);
                // Show the window
                cinemaWindow.Show();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IServiceCollection AppServiceDI()
            => new ServiceCollection().AddSingleton(new DbContextFactoryMigrator("app.db"))
                                      .AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create())
                                      .AddScoped<WatchItemRepository>()
                                      .AddScoped<IMessageBox, MessageBoxPage>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<DownloadDataService>()
                                      .AddLogging();

        private static Logger CreateLogger(string logDirectory = "log")
        {
            try
            {
                Directory.CreateDirectory(logDirectory);
            }
            catch
            {
            }

            return logDirectory.CreateLogger();
        }
    }
}
