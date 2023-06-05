using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.DbContext;
using WatchList.Core.Service.Component;

namespace WatchList.Core.Service
{
    public class WatchItemService
    {
        private const string DuplicateReplaceMessage = "The append item is a duplicate. Replace element?";

        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        private readonly IMessageBox _messageBox;

        public WatchItemService(WatchCinemaDbContext dbContext, IMessageBox messageBox)
        {
            _db = dbContext;
            _repository = new WatchItemRepository(_db);
            _messageBox = messageBox;
        }

        public PagedList<WatchItem> GetPage(WatchItemSearchRequest itemSearchRequest) => _repository.GetPage(itemSearchRequest);

        public void Remove(Guid id) => _repository.Remove(id);

        public void Replace(WatchCinemaDbContext dbContext)
        {
            var repository = new WatchItemRepository(dbContext);
            _repository.RemoveRange();
            _repository.AddRange(repository.GetAll());
        }

        public void Add(WatchItem item)
        {
            if (!IsDuplicateItem(item))
            {
                _repository.Add(item);
                return;
            }

            if (QuestionReplaceItem())
            {
                item.Id = IdDuplicateItem(item);
                Update(item);
            }
        }

        public void Edit(WatchItem oldItem, WatchItem modifiedItem)
        {
            if (IsDuplicateItem(modifiedItem))
            {
                if (QuestionReplaceItem())
                {
                    modifiedItem.Id = IdDuplicateItem(modifiedItem);
                    Remove(oldItem.Id);
                }
            }

            Update(modifiedItem);
        }

        private void Update(WatchItem item) => _repository.Update(item);

        private bool IsDuplicateItem(WatchItem item)
        {
            var selectItem = _db.WatchItem.Select(x => x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id);
            var countDuplicate = selectItem.Count();

            if (countDuplicate > 1)
            {
                throw new ArgumentException("The database is invalid. There are duplicate internal elements.");
            }

            return countDuplicate == 1;
        }

        private bool QuestionReplaceItem() => _messageBox.ShowQuestion(DuplicateReplaceMessage);

        private Guid IdDuplicateItem(WatchItem item) =>
            _db.WatchItem.First(x => x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id).Id;
    }
}
