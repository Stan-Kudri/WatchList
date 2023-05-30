using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository;
using WatchList.Core.Repository.DbContext;
using WatchList.WinForms.BindingItem.ModelBoxForm;
using WatchList.WinForms.DbContext;

namespace WatchList.WinForms
{
    public class WatchItemService
    {
        private readonly WatchCinemaDbContext _db;

        private readonly WatchItemRepository _repository;

        public WatchItemService(WatchCinemaDbContext dbContext)
        {
            _db = dbContext;
            _repository = new WatchItemRepository(_db);
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
            var duplicateItem = _db.WatchItem.FirstOrDefault(x => x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id);

            if (duplicateItem != null)
            {
                var dialogResult = MessageBoxProvider.ShowQuestionSaveItem("The append item is a duplicate. Replace element?");
                if (dialogResult)
                {
                    _repository.UpdateByID(item.ToWatchItem(), duplicateItem.Id);
                }

                return true;
            }

            return false;
        }
    }
}
