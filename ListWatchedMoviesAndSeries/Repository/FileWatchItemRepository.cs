using ListWatchedMoviesAndSeries.Models;
using System.Text.Json;

namespace ListWatchedMoviesAndSeries.Repository
{
    public class FileWatchItemRepository : IWatchItemRepository
    {
        private readonly string _path;

        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        public FileWatchItemRepository(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            _path = path;
        }
        public void Add(WatchItem item)
        {
            throw new NotImplementedException();
        }

        public List<WatchItem> GetAll()
        {
            try
            {
                using (FileStream stream = new FileStream(_path, FileMode.Open))
                {
                    var itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
                    return itemList ?? new List<WatchItem>();
                }
            }
            catch (Exception ex)
            {
                MessageBoxProvider.ShowError(ex.Message);
                return new List<WatchItem>();
            }
        }

        public void Save(List<WatchItem> items)
        {
            using (FileStream stream = new FileStream(_path, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, items, _options);
            }
        }
    }
}
