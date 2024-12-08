using System.IO;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using WatchList.Core.Extension;
using WatchList.WPF.Data;
using WatchList.WPF.Extension;

namespace WatchList.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            Log.Logger = CreateLogger();
            Log.Information("Starting WPF applications");
            var serviceCollection = new ServiceCollection();
            ViewModelLocator.AddViewModels(serviceCollection)
                            .AppServiceContainer()
                            .AppServicePageContainer()
                            .AddSerilog(Log.Logger);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                ViewModelLocator.Init(_serviceProvider);
                // Create the startup window
                var cinemaWindow = _serviceProvider.GetRequiredService<CinemaWindow>();
                // Show the window
                cinemaWindow.Show();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            Log.CloseAndFlush();
        }

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
