using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        List<WatchItem> Apply(List<WatchItem> items);
    }
}
