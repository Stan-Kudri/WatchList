using Microsoft.AspNetCore.Mvc;
using WatchList.ASP.Net.Controllers.Model;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Service;

namespace WatchList.ASP.Net.Controllers.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class WatchItemController : ControllerBase
    {
        private readonly WatchItemService _itemService;
        //private readonly IMessageBox _messageBox;
        //private readonly WatchItemRepository _itemRepository;
        //private readonly ILogger<WatchItemRepository> _logger;
        private readonly ItemSearchRequest _searchRequests;

        private readonly SortWatchItem _sortField;
        private readonly IFilterItem _filterItem;

        //private PagedList<WatchItem> _pagedList;
        private readonly Page _page;
        private readonly bool _isAscending = true;

        public WatchItemController(WatchItemService itemService,
                                    //IMessageBox messageBox,
                                    //WatchItemRepository itemRepository,
                                    //ILogger<WatchItemRepository> logger,
                                    //PagedList<WatchItem> pagedList,
                                    Page page,
                                    SortWatchItem sortWatchItem,
                                    IFilterItem filterItem)
        {
            _itemService = itemService;
            //_messageBox = messageBox;
            //_itemRepository = itemRepository;
            //_logger = logger;
            //_pagedList = pagedList;
            _page = page;
            _sortField = sortWatchItem;
            _filterItem = filterItem;
            _searchRequests = new ItemSearchRequest(_filterItem, _sortField, _page, _isAscending);
            //_pagedList = _itemService.GetPage(_searchRequests);
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem([FromBody] WatchItemModel watchItem)
        {
            try
            {
                var item = watchItem.GetWatchItem();
                await _itemService.AddAsync(item);
                return Ok(watchItem);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
