using Microsoft.AspNetCore.Mvc;
using WatchList.ASP.Net.Controllers.Extension;
using WatchList.ASP.Net.Controllers.Model;
using WatchList.ASP.Net.Controllers.Model.DuplicateModel;
using WatchList.Core.Enums;
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
            try
            {
                var item = watchItem.GetWatchItem();
                await _itemService.AddAsync(item);
                return Ok("The item has been add to the DB.");
            }
            catch
            {
                return BadRequest("The item was not add.");
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteItem(string id)
        {
            try
            {
                _itemService.Remove(id);
                return Ok($"Item with ID {id} has been removed.");
            }
            catch
            {
                return BadRequest("The item was not removed.");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] WatchItemModel watchItem, string updateId)
        {
            try
            {
                var item = watchItem.GetWatchItem(updateId);
                await _itemService.UpdateByIdAsync(updateId, item);
                return Ok($"Update item by ID:{updateId}");
            }
            catch
            {
                return BadRequest("The item was not update.");
            }
        }

        [HttpGet("pageItems")]
        public async Task<IActionResult> GetPageItems([FromQuery] List<Types> filterByTypes,
                                                      [FromQuery] List<Status> filterByStatus,
                                                      [FromQuery] List<SortFields> sortFields,
                                                      [FromQuery] int page = 1,
                                                      [FromQuery] bool isAscending = true)
        {
            try
            {
                var itemSearchRequestModel = new ItemSearchRequestModel(filterByTypes, filterByStatus, sortFields, page, isAscending);
                var itemSearchRequest = itemSearchRequestModel.GetItemSearchRequest();
                var itemsPage = _itemService.GetPage(itemSearchRequest);
                return Ok(itemsPage);
            }
            catch
            {
                return BadRequest("The request contains invalid data.");
            }
        }

        [HttpPost("addDateFromFile")]
        public async Task<IActionResult> DownloadDateFromFile(IFormFile file,
                                                              bool deleteGrade = false,
                                                              bool isUpdateDuplicateItems = true,
                                                              bool isCaseSensitive = true,
                                                              Grades grades = Grades.AnyGrade,
                                                              Types types = Types.AllType)
        {
            try
            {
                var loadRulesModel = new LoadRulesModel(deleteGrade, isUpdateDuplicateItems, isCaseSensitive, grades, types);

                var pathFile = await DownloadFile(file);
                var dbContext = new DbContextFactoryMigrator(pathFile).Create();

                var loadRuleConfig = loadRulesModel.GetLoadRulesConfigModel();
                var aggregateRules = loadRuleConfig.GetAggregateRules(_watchItemRepository);

                var repositoryDataDownload = new WatchItemRepository(dbContext, _logger);

                await _downloadDataService.Download(repositoryDataDownload, aggregateRules);

                return Ok("Add data in DB.");
            }
            catch
            {
                return BadRequest("Failed to unload data from file.");
            }
        }

        private async Task<string> DownloadFile(IFormFile dataFile)
        {
            var pathFile = Path.GetTempFileName();

            using (var stream = System.IO.File.OpenWrite(pathFile))
            {
                using (var loadStream = dataFile.OpenReadStream())
                {
                    await loadStream.CopyToAsync(stream);
                }
            }

            return pathFile;
        }
    }
}
