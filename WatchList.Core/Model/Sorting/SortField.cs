using Ardalis.SmartEnum;
using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Model.Sorting
{
    public class SortField : SmartEnum<SortField>
    {
        public static readonly SortField Title = new SortField("Title", 0, x => x.OrderBy(y => y.Title));
        public static readonly SortField Sequel = new SortField("Sequel", 1, x => x.OrderBy(y => y.Sequel));
        public static readonly SortField Status = new SortField("Status", 2, x => x.OrderBy(y => y.Status));
        public static readonly SortField Data = new SortField("Data", 3, x => x.OrderByDescending(y => y.Date));
        public static readonly SortField Grade = new SortField("Grade", 4, x => x.OrderByDescending(y => y.Grade));
        public static readonly SortField Type = new SortField("Type", 5, x => x.OrderBy(y => y.Type));

        private readonly Func<IQueryable<WatchItem>, IOrderedQueryable<WatchItem>> _orderByField;

        private SortField(string name, int value, Func<IQueryable<WatchItem>, IOrderedQueryable<WatchItem>> orderByField)
            : base(name, value)
            => _orderByField = orderByField;

        public IOrderedQueryable<WatchItem> Apply(IQueryable<WatchItem> items) => _orderByField(items);
    }
}
