using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;

namespace WatchList.ASP.Net.Controllers.Model
{
    public class ItemSearchRequestModel
    {
        public List<Types> FilterByType { get; set; }

        public List<Status> FilterByStatus { get; set; }

        public List<SortFields> SortField { get; set; }

        public int PageNumber { get; set; } = 1;

        public bool IsAscending { get; set; } = true;

        public ItemSearchRequest GetItemSearchRequest()
            => new ItemSearchRequest(new FilterWatchItem(GetFilterByTypeCinema(FilterByType), GetFilterByStatusCinema(FilterByStatus)),
                                        new SortWatchItem { SortFields = GetSortFields(SortField) },
                                        new Page(PageNumber),
                                        IsAscending);

        private IEnumerable<TypeCinema> GetFilterByTypeCinema(List<Types> typesFilter)
        {
            var filterByTypes = new HashSet<TypeCinema>();

            foreach (var type in typesFilter)
            {
                switch (type)
                {
                    case Types.Movie:
                        filterByTypes.Add(TypeCinema.Movie);
                        break;
                    case Types.Series:
                        filterByTypes.Add(TypeCinema.Series);
                        break;
                    case Types.Anime:
                        filterByTypes.Add(TypeCinema.Anime);
                        break;
                    case Types.Cartoon:
                        filterByTypes.Add(TypeCinema.Cartoon);
                        break;
                }
            }

            return filterByTypes;
        }

        private IEnumerable<StatusCinema> GetFilterByStatusCinema(List<Status> statusFilter)
        {
            var filterByStatus = new HashSet<StatusCinema>();

            foreach (var status in statusFilter)
            {
                switch (status)
                {
                    case Status.Viewed:
                        filterByStatus.Add(StatusCinema.Thrown);
                        break;
                    case Status.Planned:
                        filterByStatus.Add(StatusCinema.Planned);
                        break;
                    case Status.Look:
                        filterByStatus.Add(StatusCinema.Look);
                        break;
                    case Status.Thrown:
                        filterByStatus.Add(StatusCinema.Thrown);
                        break;
                }
            }

            return filterByStatus;
        }

        private IEnumerable<SortFieldWatchItem> GetSortFields(List<SortFields> sortFields)
        {
            var filterByStatus = new HashSet<SortFieldWatchItem>();

            foreach (var fields in sortFields)
            {
                switch (fields)
                {
                    case SortFields.Title:
                        filterByStatus.Add(SortFieldWatchItem.Title);
                        break;
                    case SortFields.Sequel:
                        filterByStatus.Add(SortFieldWatchItem.Sequel);
                        break;
                    case SortFields.Type:
                        filterByStatus.Add(SortFieldWatchItem.Type);
                        break;
                    case SortFields.Status:
                        filterByStatus.Add(SortFieldWatchItem.Status);
                        break;
                    case SortFields.Grade:
                        filterByStatus.Add(SortFieldWatchItem.Grade);
                        break;
                    case SortFields.Data:
                        filterByStatus.Add(SortFieldWatchItem.Data);
                        break;
                }
            }

            return filterByStatus;
        }
    }
}
