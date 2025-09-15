using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Serilog;
using Serilog.Core;
using WatchList.Core.Extension;
using WatchList.MudBlazors.Extension;

Log.Logger = CreateLogger();

try
{
    Log.Information("Starting web application");
    var builder = WebApplication.CreateBuilder(args);

    // Electron.NET
    builder.WebHost.UseElectron(args);

    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
    builder.AddAppService();
    builder.WebHost.UseDefaultServiceProvider(e =>
    {
        e.ValidateScopes = true;
        e.ValidateOnBuild = true;
    });
    builder.Host.UseSerilog();
    builder.Services.AddElectron();

    var app = builder.Build();

    // Конфигурация HTTP-конвейера
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    await app.StartAsync();
    if (HybridSupport.IsElectronActive)
    {
        await Electron.WindowManager.CreateWindowAsync();
    }

    await app.WaitForShutdownAsync();
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
