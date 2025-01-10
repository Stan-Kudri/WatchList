using WatchList.Core.Model.Load;
using WatchList.Core.Repository;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class DuplicateLoadRule : ILoadRule
    {
        private readonly bool _actionSelected;

        private readonly bool _updateDuplicate = false;

        private readonly bool _caseSensitive;

        private readonly WatchItemRepository _itemRepository;

        public DuplicateLoadRule(WatchItemRepository itemRepository, ILoadRulesConfig config)
        {
            var actionsWithDuplicates = config.ActionsWithDuplicates;

            _itemRepository = itemRepository;
            _actionSelected = actionsWithDuplicates.ActionSelected;
            if (_actionSelected)
            {
                if (actionsWithDuplicates.UpdateDuplicate.CheckAction == null || actionsWithDuplicates.CaseSensitive.CheckAction == null)
                {
                    throw new ArgumentNullException(nameof(actionsWithDuplicates));
                }

                _updateDuplicate = (bool)actionsWithDuplicates.UpdateDuplicate.CheckAction;
                _caseSensitive = (bool)actionsWithDuplicates.CaseSensitive.CheckAction;
            }
        }

        public WatchItemCollection Apply(WatchItemCollection items)
        {
            var idDuplicateItems = new List<Guid>();
            var idAddItems = new List<Guid>();
            var dictionaryId = new Dictionary<Guid, Guid>();

            foreach (var item in items.Items)
            {
                var selectItem = _caseSensitive && _actionSelected
                                ? _itemRepository.SelectDuplicateItems(item)
                                : _itemRepository.DuplicateItemsCaseSensitive(item);

                if (selectItem.Count == 0)
                {
                    idAddItems.Add(item.Id);
                }
                else if (_updateDuplicate && selectItem.Count > 0)
                {
                    idDuplicateItems.Add(item.Id);
                    var idDuplicateFileItem = item.Id;
                    dictionaryId.Add(idDuplicateFileItem, selectItem[0]);
                }
            }

            return new WatchItemCollection(items.Items, idAddItems, idDuplicateItems, dictionaryId);
        }
    }
}
