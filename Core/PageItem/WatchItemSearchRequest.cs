using Core.Model;
using Core.Repository;
using ListWatchedMoviesAndSeries.Models;

namespace Core.PageItem
{
    public class WatchItemSearchRequest
    {
        public FilterItem Filter { get; set; }

        public SortItem Sort { get; set; }

        public Page Page { get; set; }

        public WatchItemSearchRequest() : this(new Model.FilterItem(), new SortItem(), new Page())
        {
        }

        public WatchItemSearchRequest(Model.FilterItem filter, SortItem sort, Page page)
        {
            Filter = filter;
            Sort = sort;
            Page = page;
        }

        public bool CompareFilter(Model.FilterItem filter) => Filter.Equals(filter);

        public IQueryable<WatchItem> ApplyFilter(IQueryable<WatchItem> items) => Filter.Apply(items);

        public IQueryable<WatchItem> ApplyOrderBy(IQueryable<WatchItem> items) => Sort.Apply(items);
    }
}
