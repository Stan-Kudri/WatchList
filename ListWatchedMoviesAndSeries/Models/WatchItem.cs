using ListWatchedMoviesAndSeries.Models.Item;

namespace ListWatchedMoviesAndSeries.Models
{
    public abstract class WatchItem : ModelsBase
    {
        private string? _name = null;

        private WatchDetail? _detail = null;

        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public WatchDetail? Detail
        {
            get => _detail;
            set => SetField(ref _detail, value);
        }

        public abstract string GetView();

        public abstract string GetSequel();
    }
}
