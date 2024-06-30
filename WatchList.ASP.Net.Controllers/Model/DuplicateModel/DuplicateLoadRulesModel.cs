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

        private DuplicateLoadingRules GetUpdateDuplicateRules =>
            new DuplicateLoadingRules(DuplicateLoadingRules.UpdateDuplicate, IsUpdateDuplicateItems);

        private DuplicateLoadingRules GetCaseSensitiveDuplicateRules =>
            new DuplicateLoadingRules(DuplicateLoadingRules.CaseSensitive, IsCaseSensitive);
    }
}
