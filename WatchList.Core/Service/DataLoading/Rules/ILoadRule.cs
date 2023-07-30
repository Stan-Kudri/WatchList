namespace WatchList.Core.Service.DataLoading.Rules
{
    public interface ILoadRule
    {
        WatchItemCollection Apply(WatchItemCollection items);
    }
}
