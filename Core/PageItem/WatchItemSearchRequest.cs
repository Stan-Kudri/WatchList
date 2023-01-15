using Core.Model;
using Core.Repository;
using ListWatchedMoviesAndSeries.Models;

namespace Core.PageItem
{
    public class WatchItemSearchRequest
    {
        public WatchItemFilter Filter { get; set; }

        public Page Page { get; set; }

        public WatchItemSearchRequest() : this(new WatchItemFilter(), new Page())
        {
        }

        public WatchItemSearchRequest(WatchItemFilter filter, Page page)
        {
            Filter = filter;
            Page = page;
        }

        public bool CompareFilter(WatchItemFilter filter) => Filter.Equals(filter);

        public IQueryable<WatchItem> Apply(IQueryable<WatchItem> items) => Filter.Apply(items);
    }
}
