using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Model.ItemCinema.Components;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class FilterByTypeCinemaLoadRule : ILoadRule
    {
        public FilterByTypeCinemaLoadRule(TypeCinema typeCinema) => TypeCinemaDataLoad = typeCinema;

        public TypeCinema TypeCinemaDataLoad { get; private set; }

        public IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items)
        {
            if (TypeCinemaDataLoad == TypeCinema.AllType)
            {
                return items;
            }

            return items.Where(x => x.Type == TypeCinemaDataLoad).ToList();
        }
    }
}
