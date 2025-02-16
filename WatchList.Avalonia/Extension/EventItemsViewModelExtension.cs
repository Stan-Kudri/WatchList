using System.Collections;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Service;

namespace WatchList.Avalonia.Extension
{
    public static class EventItemsViewModelExtension
    {
        public static void RemoveRangeWatchItem(this WatchItemService itemService, IList selectItems)
        {
            foreach (var item in selectItems)
            {
                var isWatchItem = item as WatchItem;
                if (isWatchItem != null)
                {
                    itemService.Remove(isWatchItem.Id);
                }
            }
        }
    }
}
