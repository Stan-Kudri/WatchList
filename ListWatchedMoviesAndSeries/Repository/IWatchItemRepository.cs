using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.Repository
{
    public interface IWatchItemRepository
    {
        List<WatchItem> GetAll();

        void Add(WatchItem item);
        void Save(List<WatchItem> items);
    }
}
