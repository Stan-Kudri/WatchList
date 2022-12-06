using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.Repository
{
    public interface IWatchItemRepository
    {
        List<WatchItem> GetAll();

        void Add(WatchItem items);

        void Remove(Guid id);
    }
}
