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

    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    // Add services to the container.
    builder.AddAppService();
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
