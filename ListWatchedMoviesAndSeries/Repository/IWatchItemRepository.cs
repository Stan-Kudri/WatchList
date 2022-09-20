using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.Repository
{
    public interface IWatchItemRepository
    {
        List<WatchItem> GetAll();

        void Save(List<WatchItem> items);
    }
}
