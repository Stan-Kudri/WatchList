using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;

namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        PagedList<WatchItem> Apply(PagedList<WatchItem> items);
    }
}
