using MaterialSkin;
using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Repository;
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

            using var db = new FileDbContextFactory("app.db").Create();
            var migrator = new DbMigrator(db);
            migrator.Migrate();

            var serviceCollection = new ServiceCollection()
                .AddSingleton(new WatchItemRepository(db))
                .AddScoped<IMessageBox, MessageBoxShow>()
                .AddScoped<WatchItemService>()
                .AddScoped<DownloadDataService>()
                .AddScoped<MergeDatabaseForm>()
                .AddScoped<BoxCinemaForm>();

            using var contain = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
            {
                ValidateOnBuild = true,
                ValidateScopes = true,
            });

            using var scope = contain.CreateScope();

            var form = scope.ServiceProvider.GetRequiredService<BoxCinemaForm>();
            var materialSkinManager = MaterialSkinManager.Instance;

            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.DeepPurple700, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);

            Application.Run(form);
        }
    }
}
