using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Repository
{
    public interface IWatchItemRepository
    {
        List<WatchItem> GetAll();

        void Add(WatchItem items);

        void Remove(Guid id);
    }
}
