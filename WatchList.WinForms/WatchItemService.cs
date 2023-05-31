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

        public void AddItemToDatabase(CinemaModel item) => _repository.Add(item.ToWatchItem());

        public void Update(CinemaModel item) => _repository.Update(item.ToWatchItem());

        public void Remove(Guid id) => _repository.Remove(id);

        public void ReplaceDataFromNewFile(string fileName)
        {
            var factory = new FileDbContextFactory(fileName);
            var titleDbContext = factory.Create();
            var repository = new WatchItemRepository(titleDbContext);

            _repository.RemoveAllItems();
            _repository.Add(repository.GetAll());
        }

        public void EditDuplicateItem(CinemaModel oldItem, CinemaModel modifiedItem, Guid idDuplicateItem)
        {
            var idOldItem = oldItem.Id;
            UpdateByID(modifiedItem, idDuplicateItem);
            Remove(idOldItem);
        }

        public Guid? IdDuplicateItem(CinemaModel item)
        {
            var selectionItem = _db.WatchItem.Where(x => x.Title == item.Title && x.Sequel == item.Sequel && x.Type == item.Type && x.Id != item.Id);
            if (selectionItem.Any())
            {
                return selectionItem.First().Id;
            }

            return null;
        }

        public void UpdateByID(CinemaModel item, Guid? idDuplicateItem)
        {
            if (idDuplicateItem == null)
            {
                throw new ArgumentException("Duplicate element ID cannot be null.", nameof(idDuplicateItem));
            }

            _repository.UpdateByID(item.ToWatchItem(), idDuplicateItem);
        }
    }
}
