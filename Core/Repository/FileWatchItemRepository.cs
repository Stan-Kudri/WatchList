using System.Text.Encodings.Web;
using System.Text.Json;
using Core.Repository.Provider;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Repository
{
    public class FileWatchItemRepository : IWatchItemRepository
    {
        private readonly string _path;

        private readonly IFileProvider _fileProvider;

        private readonly JsonSerializerOptions _options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public FileWatchItemRepository(string path, IFileProvider? fileProvider = null)
        {
            _path = path ?? throw new ArgumentNullException("File path not specified", nameof(path));
            _fileProvider = fileProvider ?? new PhysiсFileProvider();
        }

        public List<WatchItem> GetAll()
        {
            using var stream = _fileProvider.Open(_path, FileMode.Open);
            var itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
            return itemList ?? new List<WatchItem>();
        }

        public void Save(List<WatchItem> items)
        {
            using var stream = _fileProvider.Open(_path, FileMode.Create);
            JsonSerializer.Serialize(stream, items, _options);
        }

        public List<WatchItem> GetAllByType(TypeCinema type)
        {
            using var stream = _fileProvider.Open(_path, FileMode.Open);
            var itemList = JsonSerializer.Deserialize<List<WatchItem>>(stream);
            var itemListByType = itemList?.Where(x => x.Type == type).ToList() ?? new List<WatchItem>();
            return itemListByType;
        }
    }
}
