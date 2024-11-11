using Microsoft.Extensions.Logging;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;
using WatchList.WPF.Views;

namespace WatchList.WPF.Models.ModelDataLoad
{
    public class ModelLoadDataDB
    {
        private readonly IMessageBox _messageBox;
        private readonly DownloadDataService _downloadDataService;
        private readonly ILogger<WatchItemRepository> _logger;

        public ModelLoadDataDB(IMessageBox messageBox, DownloadDataService downloadDataService, ILogger<WatchItemRepository> logger)
        {
            _messageBox = messageBox;
            _downloadDataService = downloadDataService;
            _logger = logger;
        }

        public async void CanLoadDataFromDB()
        {
            var dataLoadingWindow = new MergeDatabaseWindow(_messageBox);
            var showResult = dataLoadingWindow.ShowDialog() ?? false;

            if (!showResult)
            {
                return;
            }

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
            var loadRuleConfig = dataLoadingWindow.GetLoadRuleConfig();
            await _downloadDataService.DownloadDataByDB(dbContext, loadRuleConfig);
        }
    }
}
