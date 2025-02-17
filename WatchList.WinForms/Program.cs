using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using WatchList.Core.Extension;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WinForms.BindingItem.ModelBoxForm.Filter;
using WatchList.WinForms.BindingItem.ModelBoxForm.Sorter;
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
            Log.Logger = CreateLogger();

            try
            {
                Log.Information("Starting WinForms applications.");

                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                var serviceCollection = AppServiceDI();
                serviceCollection.AddSerilog();

                using var contain = serviceCollection.BuildServiceProvider(new ServiceProviderOptions
                {
                    ValidateOnBuild = true,
                    ValidateScopes = true,
                });

                using var scope = contain.CreateScope();

                var form = scope.ServiceProvider.GetRequiredService<BoxCinemaForm>();
                ApplyThemeMatherialForm(form);

                Application.Run(form);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly.");
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
                                      .AddScoped<IMessageBox, MessageBoxShow>()
                                      .AddScoped<WatchItemService>()
                                      .AddScoped<DownloadDataService>()
                                      .AddTransient<MergeDatabaseForm>()
                                      .AddScoped<SortWatchItemModel>()
                                      .AddScoped<FilterItemModel>()
                                      .AddTransient<BoxCinemaForm>()
                                      .AddLogging();

        private static void ApplyThemeMatherialForm(MaterialForm form)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple900, Primary.DeepPurple700, Primary.Purple50, Accent.LightBlue200, TextShade.WHITE);
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
