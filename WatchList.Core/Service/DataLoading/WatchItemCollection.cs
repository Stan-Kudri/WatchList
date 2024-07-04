using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading
{
    public class WatchItemCollection
    {
        public WatchItemCollection(IReadOnlyCollection<WatchItem> watchItems)
            : this(watchItems, new List<WatchItem>(), new List<WatchItem>(), new Dictionary<Guid, Guid>())
        {
        }

        public WatchItemCollection(
            IReadOnlyCollection<WatchItem> watchItems,
            IReadOnlyCollection<Guid> idAddItems,
            IReadOnlyCollection<Guid> idDuplicateItems,
            Dictionary<Guid, Guid> idDuplicate)
        {
            Items = watchItems;
            NewItems = Items.Where(e => idAddItems.Where(x => x == e.Id).Any()).Select(e => e).ToList();
            DuplicateItems = Items.Where(e => idDuplicateItems.Where(x => x == e.Id).Any()).Select(e => e).ToList();
            IdDuplicateFromDatabase = idDuplicate;
        }

        public WatchItemCollection(
            IReadOnlyCollection<WatchItem> watchItems,
            IReadOnlyCollection<WatchItem> itemsAdd,
            IReadOnlyCollection<WatchItem> itemsDuplicate,
            Dictionary<Guid, Guid> idDuplicate)
        {
            Items = watchItems;
            DuplicateItems = itemsDuplicate;
            IdDuplicateFromDatabase = idDuplicate;
            NewItems = itemsAdd;
        }

        public IReadOnlyCollection<WatchItem> Items { get; set; }

        public Dictionary<Guid, Guid> IdDuplicateFromDatabase { get; private set; }

        public IReadOnlyCollection<WatchItem> DuplicateItems { get; private set; }

        public IReadOnlyCollection<WatchItem> NewItems { get; private set; }
    }
}
