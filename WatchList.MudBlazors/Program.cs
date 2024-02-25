using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using WatchList.Core.Logger;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Sortable;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.MudBlazors.Message;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddSingleton(new DbContextFactoryMigrator("app.db"));
builder.Services.AddScoped(e => e.GetRequiredService<DbContextFactoryMigrator>().Create());
builder.Services.AddScoped(e => new AggregateLogging() { new ConsoleLogger(LogLevel.Trace), });
builder.Services.AddScoped(e => new WatchItemRepository(e.GetRequiredService<WatchCinemaDbContext>(), e.GetRequiredService<AggregateLogging>()));
builder.Services.AddScoped<IMessageBox, MessageBoxDialog>();
builder.Services.AddScoped<WatchItemService>();
builder.Services.AddScoped<SortWatchItem>();
builder.Services.AddScoped<IFilterItem, FilterWatchItem>();
builder.Services.AddScoped<ILogger>(e => e.GetRequiredService<AggregateLogging>());
builder.Services.AddScoped<DownloadDataService>();
builder.Logging.AddConsole();

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
