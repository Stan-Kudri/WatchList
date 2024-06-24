using WatchList.ASP.Net.Controllers.Enums;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;

namespace WatchList.ASP.Net.Controllers.Model
{
    public class ItemSearchRequestModel
    {
        public ItemSearchRequestModel()
            : this(new List<Types> { Types.Movie, Types.Anime, Types.Series, Types.Cartoon },
                   new List<Status> { Status.Viewed, Status.Look, Status.Planned, Status.Thrown },
                   new List<SortFields> { SortFields.Data, SortFields.Status, SortFields.Grade, SortFields.Sequel, SortFields.Title })
        {
        }

        public ItemSearchRequestModel(List<Types> filterByType, List<Status> filterByStatus, List<SortFields> sortField, int pageNumber = 1, bool isAscending = true)
        {
            FilterByType = filterByType;
            FilterByStatus = filterByStatus;
            SortField = sortField;
            PageNumber = pageNumber;
            IsAscending = isAscending;
        }

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

            return !filterByTypes.Any()
                    ? TypeCinema.List.Where(e => e != TypeCinema.AllType)
                    : filterByTypes;
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

            return !filterByStatus.Any()
                    ? StatusCinema.List.Where(e => e != StatusCinema.AllStatus)
                    : filterByStatus;
        }

        private IEnumerable<SortFieldWatchItem> GetSortFields(List<SortFields> sortFields)
        {
            var fields = new HashSet<SortFieldWatchItem>();

            foreach (var field in sortFields)
            {
                switch (field)
                {
                    case SortFields.Title:
                        fields.Add(SortFieldWatchItem.Title);
                        break;
                    case SortFields.Sequel:
                        fields.Add(SortFieldWatchItem.Sequel);
                        break;
                    case SortFields.Type:
                        fields.Add(SortFieldWatchItem.Type);
                        break;
                    case SortFields.Status:
                        fields.Add(SortFieldWatchItem.Status);
                        break;
                    case SortFields.Grade:
                        fields.Add(SortFieldWatchItem.Grade);
                        break;
                    case SortFields.Data:
                        fields.Add(SortFieldWatchItem.Data);
                        break;
                }
            }

            return !fields.Any()
                    ? SortFieldWatchItem.List
                    : fields;
        }
    }
}
