using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        IReadOnlyCollection<WatchItem> Apply(IReadOnlyCollection<WatchItem> items);
    }
}
