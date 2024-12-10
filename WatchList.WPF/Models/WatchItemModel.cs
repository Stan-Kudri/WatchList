using WatchList.Core.Model.ItemCinema;

namespace WatchList.WPF.Models
{
    public class WatchItemModel : WatchItem
    {
        public WatchItemModel()
            : base()
        {
        }

        public static WatchItem GetDefaultAddItem => new WatchItemModel();
    }
}
