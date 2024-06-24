using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using Serilog;
using Serilog.Core;
using WatchList.Core.Extension;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Migrations.SQLite;
using WatchList.MudBlazors.Message;

Log.Logger = CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddMudServices();

    builder.Services.AddSingleton(new DbContextFactoryMigrator("app.db"));
    builder.Services.AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create());
    builder.Services.AddScoped<WatchItemRepository>();
    builder.Services.AddScoped<IMessageBox, MessageBoxDialog>();
    //builder.Services.AddScoped<WatchItemService>();
    //builder.Services.AddScoped<SortWatchItem>();
    //builder.Services.AddScoped<IFilterItem, FilterWatchItem>();
    //builder.Services.AddScoped<DownloadDataService>();
    builder.Services.AddLogging();
    builder.WebHost.UseDefaultServiceProvider(e =>
    {
        e.ValidateScopes = true;
        e.ValidateOnBuild = true;
    });

    builder.Host.UseSerilog();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

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
