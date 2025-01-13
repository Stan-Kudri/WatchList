using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.Load.Components;
using WatchList.Core.Model.Load.ItemActions;
using WatchList.Core.Repository;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;

namespace WatchList.MudBlazors.Dialog
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0044:Make field readonly", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Private members is unused", Justification = "<Pending>")]
    public partial class LoadRuleDialog
    {
        [Inject] private WatchItemRepository WatchItemRepository { get; set; } = null!;
        [Inject] private ILogger<WatchItemRepository> Logger { get; set; } = null!;
        [Inject] private DownloadDataService DownloadDataService { get; set; } = null!;

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; } = null!;

        private readonly bool _isDeleteGrade = false;
        private bool _isConsiderDuplicates = false;

        private IEnumerable<DuplicateLoadingRules> _actionDuplicateItems = new[]
        {
            DuplicateLoadingRules.UpdateDuplicate,
            DuplicateLoadingRules.CaseSensitive
        };

        private TypeCinemaModel _selectTypeCinema = TypeCinemaModel.AllType;
        private Grade _selectGrade = Grade.AnyGrade;

        private void Close() => MudDialog.Cancel();

        private async Task UploadData(IBrowserFile fileload)
        {
            var pathFile = string.Empty;

            try
            {
                pathFile = await DownloadFile(fileload);
                var dbContext = new DbContextFactoryMigrator(pathFile).Create();
                var loadRuleConfig = GetLoadRuleConfig();
                await DownloadDataService.DownloadDataByDB(dbContext, loadRuleConfig);
                MudDialog.Cancel();
            }
            finally
            {
                if (string.IsNullOrEmpty(pathFile))
                {
                    RemoveFileByPath(pathFile);
                }
            }
        }

        private async Task<string> DownloadFile(IBrowserFile fileload)
        {
            var pathFile = Path.GetTempFileName();

            using (var stream = File.OpenWrite(pathFile))
            {
                using (var loadStream = fileload.OpenReadStream())
                {
                    await loadStream.CopyToAsync(stream);
                }
            }

            return pathFile;
        }

        private ILoadRulesConfig GetLoadRuleConfig()
        {
            var actionDuplicateItems = _isConsiderDuplicates
                ? new ActionDuplicateItems(_isConsiderDuplicates, _actionDuplicateItems.ToList())
                : new ActionDuplicateItems();

            return new BaseLoadRulesConfigModel(_isDeleteGrade, actionDuplicateItems, _selectTypeCinema.Value, _selectGrade);
        }

        private void RemoveFileByPath(string pathFile)
        {
            try
            {
                File.Delete(pathFile);
            }
            catch
            {
            }
        }
    }
}
