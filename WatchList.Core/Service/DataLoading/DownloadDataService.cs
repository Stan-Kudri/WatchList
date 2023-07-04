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
        public const int NumberOfItemPerPage = 500;

        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        private readonly IMessageBox _messageBox;

        public DownloadDataService(WatchCinemaDbContext db, IMessageBox messageBox)
        {
            _db = db;
            _repository = new WatchItemRepository(_db);
            _messageBox = messageBox;
        }

        public void Download(WatchItemRepository repository, ILoadRule processUploadData, int numberOfItemPerPage = NumberOfItemPerPage)
        {
            var searchRequest = new WatchItemSearchRequest(new FilterItem(), SortField.Title, new Page(1, numberOfItemPerPage));
            var pagedList = repository.GetPage(searchRequest);
            var dialogResultReplaceItem = DialogReplaceItemQuestion.Unknown;

            while (searchRequest.Page.Number <= pagedList.PageCount)
            {
                var itemsPage = processUploadData.Apply(pagedList);
                foreach (var item in itemsPage)
                {
                    var selectItem = _db.WatchItem.SelectIdItemsByDuplicate(item);

                    if (selectItem.Count == 0)
                    {
                        item.Id = _db.ReplaceIdIsNotFree(item);
                        _db.Add(item);
                        continue;
                    }

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
                        item.Id = selectItem[0];
                        _repository.Update(item);
                    }
                }

                searchRequest.Page.Number += 1;
                pagedList = repository.GetPage(searchRequest);
            }

            _db.SaveChanges();
        }
    }
}
