using WatchList.Core.Model.ItemCinema;
using WatchList.MudBlazors.Model;

namespace WatchList.MudBlazors.Extension
{
    public static class GetModelItemExtension
    {
        public static WatchItemModel GetItemModel(this WatchItem item)
          => new WatchItemModel(item.Title, item.Sequel, item.Date, item.Grade, item.Status, item.Type, item.Id);
    }
}
