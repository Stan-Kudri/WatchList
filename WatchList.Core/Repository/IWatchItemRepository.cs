using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;

namespace WatchList.Core.Repository
{
    public interface IWatchItemRepository
    {
        PagedList<WatchItem> GetPage(ItemSearchRequest searchRequest);

        void Add(WatchItem items);

        void Remove(Guid id);
    }
}
