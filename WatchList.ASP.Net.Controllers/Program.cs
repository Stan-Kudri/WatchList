using System.Text.Json.Serialization;
using Serilog;
using Serilog.Core;
using WatchList.ASP.Net.Controllers;
using WatchList.ASP.Net.Controllers.Model;
using WatchList.Core.Extension;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;

Log.Logger = CreateLogger();

try
{
    Log.Information("Starting WinForms applications");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSingleton(new DbContextFactoryMigrator("app.db"));
    builder.Services.AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create());
    builder.Services.AddScoped<WatchItemRepository>();
    builder.Services.AddScoped<IMessageBox, MessageBoxStub>();
    builder.Services.AddScoped<WatchItemService>();
    builder.Services.AddScoped<DownloadDataService>();
    builder.Services.AddScoped<Page>();
    builder.Services.AddLogging();
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    var app = builder.Build();

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseRouting();

    app.MapControllers();

    app.MapGet("/", () => "Hello World!");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

static Logger CreateLogger(string logDirectory = "log")
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
