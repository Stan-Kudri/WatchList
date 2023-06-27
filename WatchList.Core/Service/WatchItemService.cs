using WatchList.Core.Model.DataLoading;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.Extension;

namespace WatchList.Core.Service
{
    public class WatchItemService
    {
        public const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        private readonly IMessageBox _messageBox;

        private DialogReplaceItemQuestion _dialogResultReplaceItem;

        public WatchItemService(WatchCinemaDbContext dbContext, IMessageBox messageBox)
        {
            _db = dbContext;
            _repository = new WatchItemRepository(_db);
            _messageBox = messageBox;
            _dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;
        }

        public PagedList<WatchItem> GetPage(WatchItemSearchRequest itemSearchRequest) => _repository.GetPage(itemSearchRequest);

        public void Remove(Guid id) => _repository.Remove(id);

        public void DownloadData(WatchCinemaDbContext dbContext, ProcessUploadData dataLoadItem)
        {
            var repository = new WatchItemRepository(dbContext);
            var searchRequest = new WatchItemSearchRequest(new FilterItem(), SortField.Title, new Page(1, 500));
            var pagedList = repository.GetPage(searchRequest);

            while (searchRequest.Page.Number <= pagedList.PageCount)
            {
                var itemsPage = dataLoadItem.LoadItem(repository.GetPage(searchRequest).Items);
                foreach (var item in itemsPage)
                {
                    var selectItem = _db.WatchItem.SelectIdItemsByDuplicate(item);

                    if (selectItem.Count == 0)
                    {
                        item.Id = _db.ReplaceIdIfBusy(item);
                        _db.Add(item);
                    }

                    switch (_dialogResultReplaceItem.QuestionResult)
                    {
                        case QuestionResultEnum.Unknown:
                        case QuestionResultEnum.Yes:
                        case QuestionResultEnum.No:
                            _dialogResultReplaceItem = _messageBox.ShowDataReplaceQuestion(item.Title);
                            break;
                    }

                    if (_dialogResultReplaceItem == DialogReplaceItemQuestion.AllYes || _dialogResultReplaceItem == DialogReplaceItemQuestion.Yes)
                    {
                        item.Id = selectItem[0];
                        Update(item);
                    }
                }

                searchRequest.Page.Number += 1;
            }

            _dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;
            _db.SaveChanges();
        }

        public void Add(WatchItem item)
        {
            var selectItem = _db.WatchItem.Where(x =>
                x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id).
                Take(2).Select(x => x.Id).ToList();
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 0)
            {
                _repository.Add(item);
                return;
            }

            if (_messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
            {
                item.Id = selectItem[0];
                Update(item);
            }
        }

        public void Update(WatchItem oldItem, WatchItem modifiedItem)
        {
            var selectItem = _db.WatchItem.Where(x =>
                x.Title == modifiedItem.Title && x.Sequel == modifiedItem.Sequel && x.Type == modifiedItem.Type && x.Id != modifiedItem.Id).
                Take(2).Select(x => x.Id).ToList();
            var countDuplicate = selectItem.Count;

            if (countDuplicate == 1)
            {
                if (_messageBox.ShowQuestionSaveItem(DuplicateReplaceMessage))
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

        private void Update(WatchItem item) => _repository.Update(item);
    }
}
