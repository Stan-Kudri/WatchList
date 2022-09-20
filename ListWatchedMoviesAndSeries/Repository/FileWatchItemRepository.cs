using ListWatchedMoviesAndSeries.Models;
using System.Text.Json;

namespace ListWatchedMoviesAndSeries.Repository
{
    public class FileWatchItemRepository : IWatchItemRepository
    {
        private readonly string _path;

        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true
        };

        public FileWatchItemRepository(string path)
        {
            _path = path ?? throw new ArgumentNullException("Path");
        }

        public List<WatchItem> GetAll()
        {
            try
            {
                using FileStream stream = new(_path, FileMode.Open);
                List<WatchItem>? itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
                return itemList ?? new List<WatchItem>();
            }
            catch (Exception error)
            {
                throw new Exception("Unknown error.", error);
            }
        }

        public void Save(List<WatchItem> items)
        {
            try
            {
                using FileStream stream = new(_path, FileMode.Create);
                JsonSerializer.Serialize(stream, items, _options);
            }
            catch (NullReferenceException error)
            {
                throw new NullReferenceException("Item not null.", error);
            }
            catch (Exception error)
            {
                throw new Exception("Unknown error.", error);
            }
        }
    }
}
