using System.Linq.Expressions;
using Ardalis.SmartEnum;
using WatchList.Core.Enums;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Model.Sortable
{
    public abstract class SortFieldWatchItem : SmartEnum<SortFieldWatchItem>, ISortableSmartEnum<WatchItem>, ISortableSmartEnumOperation<WatchItem>
    {
        public static readonly SortFieldWatchItem Title = new SortType<string>("Title", SortFields.Title, e => e.Title);
        public static readonly SortFieldWatchItem Sequel = new SortType<int>("Sequel", SortFields.Sequel, e => e.Sequel);
        public static readonly SortFieldWatchItem Status = new SortType<StatusCinema>("Status", SortFields.Status, e => e.Status);
        public static readonly SortFieldWatchItem Data = new SortType<DateTime?>("Data", SortFields.Date, e => e.Date);
        public static readonly SortFieldWatchItem Grade = new SortType<int?>("Grade", SortFields.Grade, e => e.Grade);
        public static readonly SortFieldWatchItem Type = new SortType<TypeCinema>("Type", SortFields.Type, e => e.Type);

        private SortFieldWatchItem(string name, SortFields fields)
            : this(name, (int)fields)
        {
        }

        private SortFieldWatchItem(string name, int value)
            : base(name, value)
        {
        }

        public static SortFieldWatchItem FromValue(SortFields fields) => FromValue((int)fields);

        static ISortableSmartEnum<WatchItem> ISortableSmartEnumOperation<WatchItem>.DefaultValue => Title;

        static IReadOnlyCollection<ISortableSmartEnum<WatchItem>> ISortableSmartEnumOperation<WatchItem>.List => List;

        public abstract IOrderedQueryable<WatchItem> OrderBy(IQueryable<WatchItem> query, bool asc);

        public abstract IOrderedQueryable<WatchItem> ThenBy(IOrderedQueryable<WatchItem> query, bool asc);

        public override string ToString() => Name;

        private sealed class SortType<TKey> : SortFieldWatchItem
        {
            private readonly Expression<Func<WatchItem, TKey>> _expression;

            public SortType(string name, SortFields value, Expression<Func<WatchItem, TKey>> expression)
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
