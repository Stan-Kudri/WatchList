using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        List<WatchItem> Apply(PagedList<WatchItem> items);
    }
}
