using WatchList.Core.Model.ItemCinema.Components;
using WatchList.Core.Model.Load;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public class FilterByTypeCinemaLoadRule : ILoadRule
    {
        public FilterByTypeCinemaLoadRule(ILoadRulesConfig config) => TypeCinemaDataLoad = config.TypeCinemaLoad;

        public TypeCinema TypeCinemaDataLoad { get; private set; }

        public WatchItemCollection Apply(WatchItemCollection items)
        {
            if (TypeCinemaDataLoad == TypeCinema.AllType)
            {
                return items;
            }

            var changeItems = items.Items.Where(x => x.Type == TypeCinemaDataLoad).ToList();

            return new WatchItemCollection(changeItems);
        }
    }
}
