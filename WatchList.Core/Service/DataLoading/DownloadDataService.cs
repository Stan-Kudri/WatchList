using Microsoft.Extensions.Logging;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.Core.Service.DataLoading
{
    public class DownloadDataService
    {
        private readonly WatchItemRepository _repository;
        private readonly IMessageBox _messageBox;
        private readonly ILogger _logger;

        public DownloadDataService(WatchItemRepository repository, IMessageBox messageBox, ILogger logger, int numberOfItemPerPage = 500)
        {
            _repository = repository;
            _messageBox = messageBox;
            _logger = logger;
            NumberOfItemPerPage = numberOfItemPerPage;
        }

        public int NumberOfItemPerPage { get; set; }

        public async Task Download(WatchItemRepository repository, ILoadRule loadRule)
        {
            var itemSearchRequest = new ItemSearchRequest(new FilterWatchItem(), new SortWatchItem(), new Page(1, NumberOfItemPerPage));
            var pagedList = repository.GetPage(itemSearchRequest);

            while (itemSearchRequest.Page.Number <= pagedList.PageCount)
            {
                var watchItemCollection = new WatchItemCollection(pagedList);
                watchItemCollection = loadRule.Apply(watchItemCollection);

                _logger.LogInformation("Load items according to selected rules");
                AddItems(watchItemCollection);
                await UpdateItems(watchItemCollection);

                itemSearchRequest.Page.Number += 1;
                pagedList = repository.GetPage(itemSearchRequest);
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
                _repository.Add(item);
            }
        }

        private async Task UpdateItems(WatchItemCollection itemCollection)
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
                        dialogResultReplaceItem = await _messageBox.ShowDataReplaceQuestion(item.Title);
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
