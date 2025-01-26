using System;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using WatchList.Avalonia.Extension;
using WatchList.Avalonia.ViewModels;
using WatchList.Avalonia.Views;
using WatchList.Core.Extension;

namespace WatchList.Avalonia
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            try
            {
                Log.Logger = CreateLogger();
                Log.Information("Starting WPF applications");
                var serviceCollection = new ServiceCollection();
                serviceCollection.AppServiceContainer()
                                 .AppViewModelContainer()
                                 .AddSerilog(Log.Logger);
                _serviceProvider = serviceCollection.BuildServiceProvider();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
        }

        public override void Initialize()
        {
            try
            {
                AvaloniaXamlLoader.Load(this);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Initialize app exeption");
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }

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
