using Microsoft.Extensions.Logging;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;

namespace WatchList.Core.Service
{
    public class WatchItemService(WatchItemRepository itemRepository, IMessageBox messageBox, ILogger<WatchItemRepository> logger)
    {
        public const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        public PagedList<WatchItem> GetPage(ItemSearchRequest itemSearchRequest) => itemRepository.GetPage(itemSearchRequest);

        public void Remove(Guid id)
        {
            itemRepository.Remove(id);
            logger.LogInformation($"Remove item with ID: {id}");
        }

        public async Task AddAsync(WatchItem item)
        {
            var selectItem = itemRepository.SelectDuplicateItems(item);
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 0)
            {
                itemRepository.Add(item);
                return;
            }

            if (await messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
            {
                item.Id = selectItem[0];
                await Update(item);
            }
        }

        public async Task UpdateAsync(WatchItem oldItem, WatchItem modifiedItem)
        {
            var selectItem = itemRepository.SelectDuplicateItems(modifiedItem);
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 1 && oldItem.Title != modifiedItem.Title)
            {
                if (await messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
                {
                    modifiedItem.Id = selectItem[0];
                    Remove(oldItem.Id);
                    logger.LogInformation($"Update Item with ID:{oldItem.Id} on Title:{modifiedItem.Title}.\n Remove duplicate Item with ID:{selectItem[0]}");
                }
                else
                {
                    return;
                }
            }

            await Update(modifiedItem);
        }

        public async Task UpdateByIdAsync(Guid oldId, WatchItem modifiedItem)
        {
            var oldItem = GetItemById(oldId);
            await UpdateAsync(oldItem, modifiedItem);
        }

        public WatchItem GetItemById(Guid id) => itemRepository.GetItemById(id);

        private async Task Update(WatchItem item) => await itemRepository.UpdateAsync(item);
    }
}
