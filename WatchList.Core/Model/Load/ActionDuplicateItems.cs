using WatchList.Core.Model.Load.ItemActions;

namespace WatchList.Core.Model.Load
{
    public class ActionDuplicateItems
    {
        public ActionDuplicateItems()
            : this(false, new List<DuplicateLoadingRules>())
        {
        }

        public ActionDuplicateItems(bool actionSelected, List<DuplicateLoadingRules> listDuplicateLoadRule)
        {
            ActionSelected = actionSelected;

            if (!ActionSelected)
            {
                UpdateDuplicate = DuplicateLoadingRules.UpdateDuplicate;
                CaseSensitive = DuplicateLoadingRules.CaseSensitive;

                return;
            }

            if (listDuplicateLoadRule.Any(e => e.CheckAction == null))
            {
                throw new ArgumentException("Invalid data when select actions with duplicates.");
            }

            foreach (var item in listDuplicateLoadRule)
            {
                if (item == DuplicateLoadingRules.UpdateDuplicate)
                {
                    UpdateDuplicate = item;
                }

                if (item == DuplicateLoadingRules.CaseSensitive)
                {
                    CaseSensitive = item;
                }
            }
        }

        public bool ActionSelected { get; set; } = false;

        public DuplicateLoadingRules UpdateDuplicate { get; private set; } = DuplicateLoadingRules.UpdateDuplicate;

        public DuplicateLoadingRules CaseSensitive { get; private set; } = DuplicateLoadingRules.CaseSensitive;
    }
}
