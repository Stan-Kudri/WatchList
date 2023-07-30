using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading
{
    public class WatchItemCollection
    {
        public WatchItemCollection(IReadOnlyCollection<WatchItem> watchItems)
            : this(watchItems, new List<WatchItem>(), new List<WatchItem>(), new Dictionary<Guid, Guid>())
        {
        }

        public WatchItemCollection(IReadOnlyCollection<WatchItem> watchItems, IReadOnlyCollection<Guid> idAddItems, IReadOnlyCollection<Guid> idDuplicateItems, Dictionary<Guid, Guid> idDuplicate)
        {
            Items = watchItems;
            ItemsAdd = Items.Where(e => idAddItems.Where(x => x == e.Id).Any()).Select(e => e).ToList();
            ItemsDuplicate = Items.Where(e => idDuplicateItems.Where(x => x == e.Id).Any()).Select(e => e).ToList();
            IdDuplicate = idDuplicate;
        }

        public WatchItemCollection(IReadOnlyCollection<WatchItem> watchItems, IReadOnlyCollection<WatchItem> itemsAdd, IReadOnlyCollection<WatchItem> itemsDuplicate, Dictionary<Guid, Guid> idDuplicate)
        {
            Items = watchItems;
            ItemsDuplicate = itemsDuplicate;
            IdDuplicate = idDuplicate;
            ItemsAdd = itemsAdd;
        }

        public IReadOnlyCollection<WatchItem> Items { get; set; }

        public Dictionary<Guid, Guid> IdDuplicate { get; private set; }

        public IReadOnlyCollection<WatchItem> ItemsDuplicate { get; private set; }

        public IReadOnlyCollection<WatchItem> ItemsAdd { get; private set; }
    }
}
