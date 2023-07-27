namespace WatchList.Core.Model.Load.ItemActions
{
    public class IsActionWithDuplicate
    {
        public IsActionWithDuplicate(DuplicateLoadingRules rulesDuplicateLoading, bool? checkAction = null)
        {
            RulesDuplicateLoading = rulesDuplicateLoading;
            CheckAction = checkAction;
        }

        public bool? CheckAction { get; private set; }

        public DuplicateLoadingRules RulesDuplicateLoading { get; private set; }
    }
}
