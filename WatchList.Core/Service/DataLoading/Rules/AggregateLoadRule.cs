using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class AggregateLoadRule : List<ILoadRule>, ILoadRule
    {
        public AggregateLoadRule()
            : base()
        {
        }

        public AggregateLoadRule(int capacity)
            : base(capacity)
        {
        }

        public AggregateLoadRule(IEnumerable<ILoadRule> collection)
            : base(collection)
        {
        }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            foreach (var apply in this)
            {
                items = apply.Apply(items);
            }

            return items;
        }
    }
}
