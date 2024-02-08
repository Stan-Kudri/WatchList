using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WatchList.Core.Logger;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WinForms.ChildForms;
using WatchList.WinForms.Message;

namespace WatchList.WinForms
{
    public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var path = "logs";
            CreatDirectoryIfNotExists(path);

            var serviceCollection = AppServiceDI();

            serviceCollection.AddSingleton<ILogger>(e => new AggregateLogging()
            {
                new ConsoleLogger(LogLevel.Trace),
                new FileLogger(LogLevel.Trace, path)
            });

            using var contain = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true,
            });

            using var scope = contain.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<BoxCinemaForm>();
            ApplyThemeMatherialForm(form);

            var loger = scope.ServiceProvider.GetRequiredService<ILogger>();

            try
            {
                loger.LogTrace("Launch the application");
                Application.Run(form);
            }
            catch (Exception ex)
            {
                loger.LogError(ex, "Unhandled exception");
            }
        }

        private static void CreatDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static IServiceCollection AppServiceDI()
            => new ServiceCollection().AddSingleton(new DbContextFactoryMigrator("app.db"))
                                      .AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create())
                                      .AddScoped<WatchItemRepository>()
                                      .AddScoped<IMessageBox, MessageBoxShow>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<DownloadDataService>()
                                      .AddTransient<MergeDatabaseForm>()
                                      .AddTransient<BoxCinemaForm>();

        private static void ApplyThemeMatherialForm(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.DeepPurple700, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);
        }
    }
}
