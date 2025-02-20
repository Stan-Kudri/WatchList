using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Microsoft.Extensions.Logging;
using WatchList.Core.Model.Load;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;

namespace WatchList.Avalonia.Models.ModelDataLoad
{
    public class FileLoaderDB
    {
        private const string MessageSelectSingleFile = "Please select one item to download.";

        private readonly DownloadDataService _downloadDataService;
        private readonly ILogger<WatchItemRepository> _logger;
        private readonly IMessageBox _messageBox;

        public FileLoaderDB(DownloadDataService downloadDataService, ILogger<WatchItemRepository> logger, IMessageBox messageBox)
        {
            _downloadDataService = downloadDataService;
            _logger = logger;
            _messageBox = messageBox;
        }

        public async Task DownloadDataToDB(ILoadRulesConfig loadRulesConfig)
        {
            try
            {
                var file = await DoOpenFilePickerAsync();

                if (file is null)
                {
                    await _messageBox.ShowWarning(MessageSelectSingleFile);
                    return;
                }

                // Limit the text file to 1MB so that the demo won't lag.
                if ((await file.GetBasicPropertiesAsync()).Size <= 1024 * 1024 * 1)
                {
                    var pathFile = file.Path.LocalPath;

                    _logger.LogInformation($"Add item from the selected file <{0}>", pathFile);

                    var dbContext = new DbContextFactoryMigrator(pathFile).Create();
                    await _downloadDataService.DownloadDataByDB(dbContext, loadRulesConfig);
                }
                else
                {
                    throw new Exception("File exceeded 1MB limit.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
            }
        }

        private async Task<IStorageFile?> DoOpenFilePickerAsync()
        {
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop
                || desktop.MainWindow?.StorageProvider is not { } provider)
            {
                throw new NullReferenceException("Missing StorageProvider instance.");
            }

            var files = await provider.OpenFilePickerAsync(DBFilePickerOpenOption);

            return files?.Count >= 1 ? files[0] : null;
        }

        private static FilePickerOpenOptions DBFilePickerOpenOption { get; } = new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false,
            FileTypeFilter = [new("DB") { Patterns = ["*.db"], }]
        };
    }
}
