using Microsoft.AspNetCore.Mvc;
using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
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
        public async Task<IActionResult> AddItem(string title,
                                                    int sequel,
                                                    Status status,
                                                    Types type,
                                                    string? id,
                                                    DateTime? dateWatch = null,
                                                    int? grade = null)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return BadRequest();
            }

            try
            {
                var statusCinema = GetSmartEnumStatus(status);
                var typeCinema = GetSmartEnumTypeCinema(type);

                if (statusCinema == StatusCinema.Viewed)
                {
                    dateWatch ??= DateTime.UtcNow;
                    grade ??= 5;
                }

                var item = new WatchItem(title, sequel, statusCinema, typeCinema, guidId, dateWatch, grade);
                await _itemService.AddAsync(item);
                return Ok(item);
            }
            catch
            {
                return NoContent();
            }
        }

        private StatusCinema GetSmartEnumStatus(Status status)
        {
            return status switch
            {
                Status.AllStatus => StatusCinema.AllStatus,
                Status.Viewed => StatusCinema.Viewed,
                Status.Planned => StatusCinema.Planned,
                Status.Look => StatusCinema.Look,
                Status.Thrown => StatusCinema.Thrown,
                _ => StatusCinema.AllStatus,
            };
        }

        private TypeCinema GetSmartEnumTypeCinema(Types type)
        {
            return type switch
            {
                Types.AllType => TypeCinema.AllType,
                Types.Movie => TypeCinema.Movie,
                Types.Series => TypeCinema.Series,
                Types.Anime => TypeCinema.Anime,
                Types.Cartoon => TypeCinema.Cartoon,
                _ => TypeCinema.AllType,
            };
        }
    }
}
