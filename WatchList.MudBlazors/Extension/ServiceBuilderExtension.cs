using MudBlazor.Services;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Sortable;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.MudBlazors.Message;

namespace WatchList.MudBlazors.Extension
{
    public static class ServiceBuilderExtension
    {
        public static void AddAppService(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddMudServices();
            builder.Services.AddSingleton(new DbContextFactoryMigrator("app.db"));
            builder.Services.AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create());
            builder.Services.AddScoped<WatchItemRepository>();
            builder.Services.AddScoped<IMessageBox, MessageBoxDialog>();
            builder.Services.AddScoped<WatchItemService>();
            builder.Services.AddScoped<SortWatchItem>();
            builder.Services.AddScoped<IFilterItem, FilterWatchItem>();
            builder.Services.AddScoped<DownloadDataService>();
            builder.Services.AddLogging();
        }
    }
}
