using System.Text.Encodings.Web;
using System.Text.Json;
using Core.Repository.Provider;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Repository
{
    public class FileWatchItemRepository : IWatchItemRepository
    {
        private string _path;

        private readonly IFileProvider _fileProvider;

        private readonly JsonSerializerOptions _options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public FileWatchItemRepository(IFileProvider? fileProvider = null) : this(null, fileProvider)
        {
        }

        public FileWatchItemRepository(string basePath, IFileProvider? fileProvider = null)
        {
            if (basePath == null || basePath == string.Empty)
            {
                basePath = @"C:\\";
            }
            _path = Path.Combine(basePath, "GridCinema.json");
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
