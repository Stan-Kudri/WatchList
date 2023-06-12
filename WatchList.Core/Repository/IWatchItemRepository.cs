using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;

namespace WatchList.Core.Repository
{
    public interface IWatchItemRepository
    {
        public PagedList<WatchItem> GetPage(WatchItemSearchRequest searchRequest);

        public void Add(WatchItem items);

        public void Remove(Guid id);
    }
}
