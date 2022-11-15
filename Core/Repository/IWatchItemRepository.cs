using ListWatchedMoviesAndSeries.Models;

namespace ListWatchedMoviesAndSeries.Repository
{
    public interface IWatchItemRepository
    {
        List<WatchItem> GetAll();

        void Add(WatchItem items);

        void Delite(Guid id);
    }
}
