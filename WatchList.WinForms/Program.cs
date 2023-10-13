using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WatchList.Core.Logger;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WinForms.BuilderDbContext;
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

            var serviceCollection = new ServiceCollection()
                .AddSingleton(new FileDbContextFactory("app.db"))
                .AddScoped(e => e.GetRequiredService<FileDbContextFactory>().Create())
                .AddScoped<DbMigrator>()
                .AddScoped<WatchItemRepository>(e => new WatchItemRepository(e.GetRequiredService<WatchCinemaDbContext>(), e.GetRequiredService<AggregateLogging>()))
                .AddScoped<IMessageBox, MessageBoxShow>()
                .AddScoped<WatchItemService>()
                .AddScoped<DownloadDataService>()
                .AddTransient<MergeDatabaseForm>()
                .AddTransient<BoxCinemaForm>()
                .AddSingleton(e => new ConsoleLogger(LogLevel.Information))
                .AddSingleton(e => new FileLogger(LogLevel.Trace, path))
                .AddSingleton<ILogger>(e => e.GetRequiredService<ConsoleLogger>())
                .AddSingleton<ILogger>(e => e.GetRequiredService<FileLogger>())
                .AddSingleton(e => new AggregateLogging() { e.GetRequiredService<ConsoleLogger>(), e.GetRequiredService<FileLogger>() });

            using var contain = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true,
            });

            using var scope = contain.CreateScope();

            scope.ServiceProvider.GetRequiredService<DbMigrator>().Migrate();
            var form = scope.ServiceProvider.GetRequiredService<BoxCinemaForm>();
            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.DeepPurple700, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);

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
    }
}
