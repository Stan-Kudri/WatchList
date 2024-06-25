using WatchList.Core.Enums;
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
                   new List<SortFields> { SortFields.Date, SortFields.Status, SortFields.Grade, SortFields.Sequel, SortFields.Title })
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

            typesFilter.ForEach(e => filterByTypes.Add(TypeCinema.FromValue((int)e)));

            return !filterByTypes.Any()
                    ? TypeCinema.List.Where(e => e != TypeCinema.AllType)
                    : filterByTypes.Where(e => e != TypeCinema.AllType);
        }

        private IEnumerable<StatusCinema> GetFilterByStatusCinema(List<Status> statusFilter)
        {
            var filterByStatus = new HashSet<StatusCinema>();

            statusFilter.ForEach(e => filterByStatus.Add(StatusCinema.FromValue((int)e)));

            return !filterByStatus.Any()
                    ? StatusCinema.List.Where(e => e != StatusCinema.AllStatus)
                    : filterByStatus.Where(e => e != StatusCinema.AllStatus);
        }

        private IEnumerable<SortFieldWatchItem> GetSortFields(List<SortFields> sortFields)
        {
            var fields = new HashSet<SortFieldWatchItem>();

            sortFields.ForEach(e => fields.Add(SortFieldWatchItem.FromValue((int)e)));

            return !fields.Any()
                    ? SortFieldWatchItem.List
                    : fields;
        }
    }
}
