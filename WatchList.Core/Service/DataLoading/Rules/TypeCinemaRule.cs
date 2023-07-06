using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.PageItem;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class TypeCinemaRule : ILoadRule
    {
        public TypeCinemaRule(TypeCinema typeCinema) => TypeCinemaDataLoad = typeCinema;

        public TypeCinema TypeCinemaDataLoad { get; private set; }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            if (TypeCinemaDataLoad == TypeCinema.AllType)
            {
                return items;
            }
            else
            {
                var itemCollection = new PagedList<WatchItem>(items.Where(x => x.Type == TypeCinemaDataLoad).AsQueryable());
                return itemCollection;
            }
        }
    }
}
