using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.DbContext;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.DbContext;
using WatchList.WinForms.Message;

namespace WatchList.WinForms
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

        public PagedList<WatchItem> GetPageList(WatchItemSearchRequest itemSearchRequest) => _repository.GetPageCinema(itemSearchRequest);

        public void Remove(Guid id) => _repository.Remove(id);

        public void ReplaceDataFromNewFile(string fileName)
        {
            var factory = new FileDbContextFactory(fileName);
            var titleDbContext = factory.Create();
            var repository = new WatchItemRepository(titleDbContext);

            _repository.RemoveAllItems();
            _repository.Add(repository.GetAll());
        }

        public void AddItemToDatabase(CinemaModel item)
        {
            if (!IsDuplicateItem(item))
            {
                _repository.Add(item.ToWatchItem());
            }
        }

        public void EditItemToDatabase(CinemaModel oldItem, CinemaModel modifiedItem)
        {
            if (IsDuplicateItem(modifiedItem))
            {
                var idEditItem = oldItem.Id;
                Remove(idEditItem);
            }
            else
            {
                _repository.Update(modifiedItem.ToWatchItem());
            }
        }

        private bool IsDuplicateItem(CinemaModel item)
        {
            var selectionItem = _db.WatchItem.Where(x => x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id).SingleOrDefault();

            if (selectionItem != null)
            {
                if (_messageBox.ShowQuestion(DuplicateReplaceMessage))
                {
                    _repository.UpdateByID(item.ToWatchItem(), selectionItem.Id);
                }

                return true;
            }

            return false;
        }
    }
}
