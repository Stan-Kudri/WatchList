using Ardalis.SmartEnum;
using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Model.Sorting
{
    public class WatchItemSortField : SmartEnum<WatchItemSortField>
    {
        public static readonly WatchItemSortField Title = new WatchItemSortField("Title", 0, x => x.OrderBy(y => y.Title));
        public static readonly WatchItemSortField Sequel = new WatchItemSortField("Sequel", 1, x => x.OrderBy(y => y.Sequel));
        public static readonly WatchItemSortField Status = new WatchItemSortField("Status", 2, x => x.OrderBy(y => y.Status));
        public static readonly WatchItemSortField Data = new WatchItemSortField("Data", 3, x => x.OrderByDescending(y => y.Date));
        public static readonly WatchItemSortField Grade = new WatchItemSortField("Grade", 4, x => x.OrderByDescending(y => y.Grade));
        public static readonly WatchItemSortField Type = new WatchItemSortField("Type", 5, x => x.OrderBy(y => y.Type));

        private readonly Func<IQueryable<WatchItem>, IOrderedQueryable<WatchItem>> _orderByField;

        private WatchItemSortField(string name, int value, Func<IQueryable<WatchItem>, IOrderedQueryable<WatchItem>> orderByField)
            : base(name, value)
            => _orderByField = orderByField;

        public IOrderedQueryable<WatchItem> Apply(IQueryable<WatchItem> items) => _orderByField(items);
    }
}
