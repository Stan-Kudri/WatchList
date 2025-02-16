using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository;

namespace WatchList.Avalonia.Extension
{
    public static class LoggerExtension
    {
        public static void AddInformationEditItem(this ILogger<WatchItemRepository> logger, WatchItem defaultItem, WatchItem item)
        {
            if (defaultItem.Title == item.Title)
            {
                logger.LogInformation($"Edit Item : {item.Title}");
            }
            else
            {
                logger.LogInformation($"Edit Item :{defaultItem.Title} -> {item.Title}");
            }
        }
    }
}
