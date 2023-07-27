using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.Extension;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class DuplicateLoadRule : ILoadRule
    {
        private readonly ActionsWithDuplicates _actionsWithDuplicates;

        private readonly bool _actionSelected;

        private readonly bool _updateDuplicate = false;

        private readonly bool _caseSensitive;

        private readonly WatchItemRepository _watchItemRepository;

        private readonly WatchCinemaDbContext _dbContext;

        private readonly IMessageBox _messageBox;

        public DuplicateLoadRule(WatchCinemaDbContext db, IMessageBox messageBox, ActionsWithDuplicates actionsWithDuplicates)
        {
            _dbContext = db;
            _watchItemRepository = new WatchItemRepository(db);
            _messageBox = messageBox;
            _actionSelected = actionsWithDuplicates.ActionSelected;
            if (_actionSelected)
            {
                _updateDuplicate = (bool)actionsWithDuplicates.UpdateDuplicate.CheckAction;
                _caseSensitive = (bool)actionsWithDuplicates.CaseSensitive.CheckAction;
            }
        }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            var titles = items.ToList();
            var duplicateItems = new List<WatchItem>();

            foreach (var item in items)
            {
                var selectItem = _caseSensitive && _actionSelected ? _dbContext.WatchItem.SelectDuplicateItems(item) : _dbContext.WatchItem.DuplicateItemsCaseSensitive(item);
                if (selectItem.Count != 0)
                {
                    duplicateItems.Add(item);
                }
            }

            UpdateDuplicateItem(items, duplicateItems);
            return items.Where(e => !duplicateItems.Contains(e)).ToList();
        }

        private void UpdateDuplicateItem(IReadOnlyCollection<WatchItem> items, List<WatchItem> duplicateItems)
        {
            if (_updateDuplicate == true)
            {
                var dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;

                foreach (var item in duplicateItems)
                {
                    switch (dialogResultReplaceItem.QuestionResult)
                    {
                        case QuestionResultEnum.Unknown:
                        case QuestionResultEnum.Yes:
                        case QuestionResultEnum.No:
                            dialogResultReplaceItem = _messageBox.ShowDataReplaceQuestion(item.Title);
                            break;
                    }

                    if (dialogResultReplaceItem.IsYes)
                    {
                        var idDuplicateItem = _actionsWithDuplicates.CaseSensitive.CheckAction == true
                            ? items.Where(e => e.Title == item.Title).Take(1).Select(x => x.Id).ToList()[0]
                            : items.Where(e => e.TitleNormalized == item.TitleNormalized).Take(2).Select(x => x.Id).ToList()[0];
                        item.Id = idDuplicateItem;
                        _watchItemRepository.Update(item);
                    }
                }
            }
        }
    }
}
