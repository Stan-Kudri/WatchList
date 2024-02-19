using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Sortable;

namespace WatchList.Core.PageItem
{
    public class ItemSearchRequest
    {
        public ItemSearchRequest()
            : this(new FilterWatchItem(), new SortItem<WatchItem, SortFieldWatchItem>(), new Page(), true)
        {
        }

        public ItemSearchRequest(IFilterItem filter, SortItem<WatchItem, SortFieldWatchItem> sort, Page page, bool isAscending = true)
        {
            Filter = filter;
            Sort = sort;
            Page = page;
            IsAscending = isAscending;
        }

        public IFilterItem Filter { get; set; }

        public SortItem<WatchItem, SortFieldWatchItem> Sort { get; set; }

        public Page Page { get; set; }

        public bool IsAscending { get; set; } = true;

        public bool CompareFilter(FilterItem filter) => Filter.Equals(filter);

        public IQueryable<WatchItem> ApplyFilter(IQueryable<WatchItem> items) => Filter.Apply(items);

        public IQueryable<WatchItem> ApplyOrderBy(IQueryable<WatchItem> items) => Sort.Apply(items, IsAscending);
    }
}
