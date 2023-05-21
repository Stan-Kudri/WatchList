using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sorting;

namespace WatchList.Core.PageItem
{
    public class WatchItemSearchRequest
    {
        public WatchItemSearchRequest()
            : this(new FilterItem(), SortField.Title, new Page())
        {
        }

        public WatchItemSearchRequest(FilterItem filter, SortField sort, Page page)
        {
            Filter = filter;
            Sort = sort;
            Page = page;
        }

        public FilterItem Filter { get; set; }

        public SortField Sort { get; set; }

        public Page Page { get; set; }

        public bool CompareFilter(FilterItem filter) => Filter.Equals(filter);

        public IQueryable<WatchItem> ApplyFilter(IQueryable<WatchItem> items) => Filter.Apply(items);

        public IQueryable<WatchItem> ApplyOrderBy(IQueryable<WatchItem> items) => Sort.Apply(items);
    }
}
