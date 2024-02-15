using System.Linq.Expressions;
using Ardalis.SmartEnum;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Sortable
{
    public abstract class SortFieldWatchItem : SmartEnum<SortFieldWatchItem>, ISortableSmartEnum<WatchItem>, ISortableSmartEnumOperation<WatchItem>
    {
        public static readonly SortFieldWatchItem Title = new SortType<string>("Title", 0, e => e.Title);
        public static readonly SortFieldWatchItem Sequel = new SortType<int>("Sequel", 1, e => e.Sequel);
        public static readonly SortFieldWatchItem Status = new SortType<StatusCinema>("Status", 2, e => e.Status);
        public static readonly SortFieldWatchItem Data = new SortType<DateTime?>("Data", 3, e => e.Date);
        public static readonly SortFieldWatchItem Grade = new SortType<int?>("Grade", 4, e => e.Grade);
        public static readonly SortFieldWatchItem Type = new SortType<TypeCinema>("Type", 5, e => e.Type);

        private readonly Func<IQueryable<WatchItem>, IOrderedQueryable<WatchItem>> _orderByField;

        private SortFieldWatchItem(string name, int value)
            : base(name, value)
        {
        }

        static ISortableSmartEnum<WatchItem> ISortableSmartEnumOperation<WatchItem>.DefaultValue => Title;

        static IReadOnlyCollection<ISortableSmartEnum<WatchItem>> ISortableSmartEnumOperation<WatchItem>.List => List;

        public abstract IOrderedQueryable<WatchItem> OrderBy(IQueryable<WatchItem> query, bool asc);

        public abstract IOrderedQueryable<WatchItem> ThenBy(IOrderedQueryable<WatchItem> query, bool asc);

        public override string ToString() => Name;

        private sealed class SortType<TKey> : SortFieldWatchItem
        {
            private readonly Expression<Func<WatchItem, TKey>> _expression;

            public SortType(string name, int value, Expression<Func<WatchItem, TKey>> expression)
                : base(name, value)
            {
                _expression = expression;
            }

            public override IOrderedQueryable<WatchItem> OrderBy(IQueryable<WatchItem> query, bool asc)
            => asc ? query.OrderBy(_expression) : query.OrderByDescending(_expression);

            public override IOrderedQueryable<WatchItem> ThenBy(IOrderedQueryable<WatchItem> query, bool asc)
                => asc ? query.ThenBy(_expression) : query.ThenByDescending(_expression);
        }
    }
}
