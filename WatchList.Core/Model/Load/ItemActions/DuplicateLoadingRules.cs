using Ardalis.SmartEnum;

namespace WatchList.Core.Model.Load.ItemActions
{
    public class DuplicateLoadingRules : SmartEnum<DuplicateLoadingRules>
    {
        public static readonly DuplicateLoadingRules UpdateDuplicate = new DuplicateLoadingRules("Update duplicate item", 0, null);

        public static readonly DuplicateLoadingRules CaseSensitive = new DuplicateLoadingRules("Case sensitive", 1, null);

        public DuplicateLoadingRules(DuplicateLoadingRules loadingRules, bool? checkAction)
            : this(loadingRules.Name, loadingRules.Value, checkAction)
        {
        }

        public DuplicateLoadingRules(string name, int value, bool? checkAction)
            : base(name, value) => CheckAction = checkAction;

        public bool? CheckAction { get; private set; }
    }
}
