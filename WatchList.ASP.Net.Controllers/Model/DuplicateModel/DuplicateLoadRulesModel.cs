using WatchList.Core.Model.Load.ItemActions;

namespace WatchList.ASP.Net.Controllers.Model.DuplicateModel
{
    public class DuplicateLoadRulesModel
    {
        public DuplicateLoadRulesModel()
        {
        }

        public DuplicateLoadRulesModel(bool isUpdateDuplicateItems, bool isCaseSensitive)
        {
            IsUpdateDuplicateItems = isUpdateDuplicateItems;
            IsCaseSensitive = isCaseSensitive;
        }

        public bool IsUpdateDuplicateItems { get; set; } = true;

        public bool IsCaseSensitive { get; set; } = true;

        public List<DuplicateLoadingRules> GetDuplicateLoadRules()
            => new List<DuplicateLoadingRules>() { GetUpdateDuplicateRules, GetCaseSensitiveDuplicateRules };

        private DuplicateLoadingRules GetUpdateDuplicateRules => !IsUpdateDuplicateItems
                ? new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, false)
                : new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, true);

        private DuplicateLoadingRules GetCaseSensitiveDuplicateRules => !IsCaseSensitive
                ? new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, false)
                : new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, true);
    }
}
