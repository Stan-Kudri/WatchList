using WatchList.Core.Model.Filter;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Model.Sorting;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading.Rules;
using WatchList.Core.Service.Extension;

namespace WatchList.Core.Service.DataLoading
{
    public class DownloadDataService
    {
        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        private readonly IMessageBox _messageBox;

        public DownloadDataService(WatchCinemaDbContext db, IMessageBox messageBox)
        {
            _db = db;
            db.ChangeTracker.Clear();
            _repository = new WatchItemRepository(_db);
            _messageBox = messageBox;
        }

        public int NumberOfItemPerPage { get; set; } = 500;

        public void Download(WatchItemRepository repository, ILoadRule loadRule)
        {
            var searchRequest = new WatchItemSearchRequest(new FilterItem(), SortField.Title, new Page(1, NumberOfItemPerPage));
            var pagedList = repository.GetPage(searchRequest);

            while (searchRequest.Page.Number <= pagedList.PageCount)
            {
                var watchItemCollection = new WatchItemCollection(pagedList);
                watchItemCollection = loadRule.Apply(watchItemCollection);

                AddItems(watchItemCollection);
                UpdateItems(watchItemCollection);

                searchRequest.Page.Number += 1;
                pagedList = repository.GetPage(searchRequest);
            }
        }

        private void AddItems(WatchItemCollection itemCollection)
        {
            if (itemCollection.NewItems == null || itemCollection.NewItems.Count <= 0)
            {
                return;
            }

            foreach (var item in itemCollection.NewItems)
            {
                item.Id = _db.ReplaceIdIsNotFree(item);
                _repository.Add(item);
            }
        }

        private void UpdateItems(WatchItemCollection itemCollection)
        {
            var dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;

            if (itemCollection.DuplicateItems == null || itemCollection.DuplicateItems.Count <= 0)
            {
                return;
            }

            foreach (var item in itemCollection.DuplicateItems)
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
                    if (itemCollection.IdDuplicateFromDatabase.TryGetValue(item.Id, out Guid value))
                    {
                        item.Id = value;
                        _repository.Update(item);
                    }
                    else
                    {
                        throw new ArgumentException("Element not found with id.");
                    }
                }
            }
        }
    }
}
