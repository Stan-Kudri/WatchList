using Microsoft.AspNetCore.Mvc;
using WatchList.ASP.Net.Controllers.Enums;
using WatchList.ASP.Net.Controllers.Model;
using WatchList.Core.Service;

namespace WatchList.ASP.Net.Controllers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class WatchItemController : ControllerBase
    {
        private readonly WatchItemService _itemService;

        public WatchItemController(WatchItemService itemService)
        {
            _itemService = itemService;
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
    }
}
