using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;

namespace WatchList.Core.Service
{
    public class WatchItemService
    {
        public const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        private readonly WatchItemRepository _repository;

        private readonly IMessageBox _messageBox;

        public WatchItemService(WatchItemRepository itemRepository, IMessageBox messageBox)
        {
            _repository = itemRepository;
            _messageBox = messageBox;
        }

        public PagedList<WatchItem> GetPage(ItemSearchRequest itemSearchRequest) => _repository.GetPage(itemSearchRequest);

        public void Remove(Guid id) => _repository.Remove(id);

        public async Task AddAsync(WatchItem item)
        {
            var selectItem = _repository.SelectDuplicateItems(item);
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 0)
            {
                _repository.Add(item);
                return;
            }

            if (await _messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
            {
                item.Id = selectItem[0];
                Update(item);
            }
        }

        public async Task UpdateAsync(WatchItem oldItem, WatchItem modifiedItem)
        {
            var selectItem = _repository.SelectDuplicateItems(modifiedItem);
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 1 && oldItem.Title != modifiedItem.Title)
            {
                if (await _messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
                {
                    modifiedItem.Id = selectItem[0];
                    Remove(oldItem.Id);
                }
                else
                {
                    return;
                }
            }

            Update(modifiedItem);
        }

        public async Task UpdateByIdAsync(Guid oldId, WatchItem modifiedItem)
        {
            var oldItem = GetItemById(oldId);
            await UpdateAsync(oldItem, modifiedItem);
        }

        public WatchItem GetItemById(Guid id)
            => _repository.GetItemById(id);

        private void Update(WatchItem item)
            => _repository.Update(item);
    }
}
