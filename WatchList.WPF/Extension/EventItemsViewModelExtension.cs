using System.Collections;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Service;

namespace WatchList.WPF.Extension
{
    public static class EventItemsViewModelExtension
    {
        public static void RemoveRangeWatchItem(this WatchItemService itemService, IList selectItems)
        {
            foreach (var item in selectItems)
            {
                if (item is WatchItem isWatchItem)
                {
                    itemService.Remove(isWatchItem.Id);
                }
            }
        }
    }
}
