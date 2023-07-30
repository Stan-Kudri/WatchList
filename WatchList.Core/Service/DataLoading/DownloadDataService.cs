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
            var dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;

            while (searchRequest.Page.Number <= pagedList.PageCount)
            {
                var watchItemCollection = new WatchItemCollection(pagedList);
                watchItemCollection = loadRule.Apply(watchItemCollection);

                if (watchItemCollection.ItemsAdd?.Count > 0)
                {
                    foreach (var item in watchItemCollection.ItemsAdd)
                    {
                        item.Id = _db.ReplaceIdIsNotFree(item);
                        _db.Add(item);
                    }
                }

                if (watchItemCollection.ItemsDuplicate?.Count > 0)
                {
                    foreach (var item in watchItemCollection.ItemsDuplicate)
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
                            if (watchItemCollection.IdDuplicate.TryGetValue(item.Id, out Guid value))
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

                searchRequest.Page.Number += 1;
                pagedList = repository.GetPage(searchRequest);
            }

            _db.SaveChanges();
        }
    }
}
