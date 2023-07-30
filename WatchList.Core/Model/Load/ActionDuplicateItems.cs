using WatchList.Core.Model.Load.ItemActions;

namespace WatchList.Core.Model.Load
{
    public class ActionDuplicateItems
    {
        public ActionDuplicateItems()
            : this(false, new List<IsActionWithDuplicate>())
        {
        }

        public ActionDuplicateItems(bool actionSelected, List<IsActionWithDuplicate> listDuplicateLoadRule)
        {
            ActionSelected = actionSelected;

            if (!ActionSelected)
            {
                UpdateDuplicate = new IsActionWithDuplicate(DuplicateLoadingRules.UpdateDuplicate, null);
                CaseSensitive = new IsActionWithDuplicate(DuplicateLoadingRules.CaseSensitive, null);

                return;
            }

            if (listDuplicateLoadRule.Where(e => e.CheckAction == null).Any())
            {
                throw new ArgumentException("Incorrect date.");
            }

            foreach (var item in listDuplicateLoadRule)
            {
                if (item.RulesDuplicateLoading == DuplicateLoadingRules.UpdateDuplicate)
                {
                    UpdateDuplicate = item;
                }

                if (item.RulesDuplicateLoading == DuplicateLoadingRules.CaseSensitive)
                {
                    CaseSensitive = item;
                }
            }
        }

        public bool ActionSelected { get; set; } = false;

        public IsActionWithDuplicate UpdateDuplicate { get; private set; }

        public IsActionWithDuplicate CaseSensitive { get; private set; }
    }
}
