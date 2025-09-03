using Microsoft.Extensions.Logging;
using WatchList.Core.Enums;
using WatchList.Core.Exceptions;
using WatchList.Core.Extension;
using WatchList.Core.Model.Filter;
using WatchList.Core.Model.Load;
using WatchList.Core.Model.QuestionResult;
using WatchList.Core.Model.Sortable;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.Db;
using WatchList.Core.Service.Component;
using WatchList.Core.Service.DataLoading.Rules;

namespace WatchList.Core.Service.DataLoading
{
    public class DownloadDataService(WatchItemRepository repository,
                                     IMessageBox messageBox,
                                     ILogger<DownloadDataService> logger,
                                     ILogger<WatchItemRepository> loggerWatchItemRepository,
                                     int numberOfItemPerPage = 500)
    {
        public int NumberOfItemPerPage { get; set; } = numberOfItemPerPage;

        public async Task DownloadDataByDB(WatchCinemaDbContext dbContext, ILoadRulesConfig loadRuleConfig)
        {
            var aggregateRules = loadRuleConfig.GetAggregateRules(repository);
            var repositoryDataDownload = new WatchItemRepository(dbContext, loggerWatchItemRepository);
            await Download(repositoryDataDownload, aggregateRules);
        }

        public async Task Download(WatchItemRepository repository, ILoadRule loadRule)
        {
            var itemSearchRequest = new ItemSearchRequest(
                                                            new FilterWatchItem(),
                                                            new SortWatchItem(),
                                                            new Page(1, NumberOfItemPerPage));
            var pagedList = repository.GetPage(itemSearchRequest);

            while (itemSearchRequest.Page.Number <= pagedList.PageCount)
            {
                var watchItemCollection = new WatchItemCollection(pagedList);
                watchItemCollection = loadRule.Apply(watchItemCollection);

                logger.LogInformation("Load items according to selected rules");
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
                repository.Add(item);
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
                        dialogResultReplaceItem = await messageBox.ShowDataReplaceQuestion(item.Title);
                        break;
                }

                if (dialogResultReplaceItem.IsYes)
                {
                    if (itemCollection.IdDuplicateFromDatabase.TryGetValue(item.Id, out Guid value))
                    {
                        item.Id = value;
                        await repository.UpdateAsync(item);
                    }
                    else
                    {
                        throw new BusinessLogicException("Element not found with id.");
                    }
                }
            }
        }
    }
}
