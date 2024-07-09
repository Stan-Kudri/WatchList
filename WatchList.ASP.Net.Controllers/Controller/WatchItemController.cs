using Microsoft.AspNetCore.Mvc;
using WatchList.ASP.Net.Controllers.Model;
using WatchList.ASP.Net.Controllers.Model.DuplicateModel;
using WatchList.Core.Repository;
using WatchList.Core.Service;
using WatchList.Core.Service.DataLoading;
using WatchList.Migrations.SQLite;

namespace WatchList.ASP.Net.Controllers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class WatchItemController : ControllerBase
    {
        private readonly WatchItemRepository _watchItemRepository;
        private readonly WatchItemService _itemService;
        private readonly DownloadDataService _downloadDataService;
        private readonly ILogger<WatchItemRepository> _logger;

        public WatchItemController(WatchItemService itemService, WatchItemRepository watchItemRepository, DownloadDataService downloadDataService)
        {
            _itemService = itemService;
            _watchItemRepository = watchItemRepository;
            _downloadDataService = downloadDataService;
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem([FromBody] WatchItemModel watchItem)
        {
            var item = watchItem.GetWatchItem();
            await _itemService.AddAsync(item);

            return CreatedAtAction(
                                    nameof(AddItem),
                                    new { id = item.Id },
                                    item);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteItem(Guid id)
        {
            _itemService.Remove(id);
            return Ok($"Item with ID {id} has been removed.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] WatchItemModel watchItem, Guid updateId)
        {
            var item = watchItem.GetWatchItem(updateId);
            await _itemService.UpdateByIdAsync(updateId, item);
            return Ok($"Update item by ID:{updateId}");
        }

        [HttpGet("pageItems")]
        public async Task<IActionResult> GetPageItems([FromQuery] ItemSearchRequestModel itemSearchRequestModel)
        {
            var itemSearchRequest = itemSearchRequestModel.GetItemSearchRequest();
            var itemsPage = _itemService.GetPage(itemSearchRequest);
            return Ok(itemsPage);
        }

        [HttpPost("addDataFromDB")]
        public async Task<IActionResult> DownloadDataFromDB(IFormFile file, [FromForm] LoadRulesModel loadRulesModel)
        {
            var pathFile = await DownloadFile(file);
            var dbContext = new DbContextFactoryMigrator(pathFile).Create();
            var loadRuleConfig = loadRulesModel.GetLoadRulesConfigModel();
            await _downloadDataService.DownloadDataByDB(dbContext, loadRuleConfig);
            return Ok("The data has been added to the database.");
        }

        private async Task<string> DownloadFile(IFormFile dataFile)
        {
            var pathFile = Path.GetTempFileName();

            using (var stream = System.IO.File.OpenWrite(pathFile))
            {
                using var loadStream = dataFile.OpenReadStream();
                await loadStream.CopyToAsync(stream);
            }

            return pathFile;
        }
    }
}
