using Microsoft.Extensions.Logging;
using WatchList.Core.Model.Load;
using WatchList.Core.Repository;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;

namespace WatchList.WPF.Models.ModelDataLoad
{
    public class FileLoaderDB
    {
        private readonly DownloadDataService _downloadDataService;
        private readonly ILogger<WatchItemRepository> _logger;

        public FileLoaderDB(DownloadDataService downloadDataService, ILogger<WatchItemRepository> logger)
        {
            _downloadDataService = downloadDataService;
            _logger = logger;
        }

        public async void DownloadDataToDB(ILoadRulesConfig loadRulesConfig)
        {
            using OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".db"; // Required file extension 
            fileDialog.Filter = "Text documents (.db)|*.db"; // Optional file extensions

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var pathFile = fileDialog.FileName;
            _logger.LogInformation($"Add item from the selected file <{0}>", pathFile);

            var dbContext = new DbContextFactoryMigrator(pathFile).Create();
            await _downloadDataService.DownloadDataByDB(dbContext, loadRulesConfig);
        }
    }
}
