using Ardalis.SmartEnum;

namespace WatchList.Core.Model.Load.ItemActions
{
    public class DuplicateLoadingRules : SmartEnum<DuplicateLoadingRules>
    {
        public static readonly DuplicateLoadingRules UpdateDuplicate = new DuplicateLoadingRules("Update duplicate item", 0);

        public static readonly DuplicateLoadingRules CaseSensitive = new DuplicateLoadingRules("Case sensitive", 1);

        public DuplicateLoadingRules(string name, int value)
            : base(name, value)
        {
        }
    }
}
