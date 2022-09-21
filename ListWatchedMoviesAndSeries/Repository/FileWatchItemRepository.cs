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
            _path = path ?? throw new ArgumentNullException("File path not specified");
        }

        public List<WatchItem> GetAll()
        {
            using FileStream stream = new(_path, FileMode.Open);
            List<WatchItem>? itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
            return itemList ?? new List<WatchItem>();
        }

        public void Save(List<WatchItem> items)
        {
            using FileStream stream = new(_path, FileMode.Create);
            JsonSerializer.Serialize(stream, items, _options);
        }
    }
}
