using WatchList.Core.Model.ItemCinema;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        ICollection<WatchItem> Apply(ICollection<WatchItem> items);
    }
}
