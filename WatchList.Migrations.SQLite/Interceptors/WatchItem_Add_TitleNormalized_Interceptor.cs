using WatchList.Core.Model.ItemCinema;
using WatchList.Core.PageItem;
using WatchList.Core.Repository.Db;
using WatchList.Core.Repository.Extension;

namespace WatchList.Migrations.SQLite.Interceptors
{
    internal class WatchItem_Add_TitleNormalized_Interceptor : IMigrationInterceptor
    {
        public void Intercept(WatchCinemaDbContext dbContext)
        {
            var page = new Page(1, 100);
            var items = dbContext.WatchItem.GetPagedList(page);
            UpdateData(items, dbContext);
            while (items.HasNextPage)
            {
                page.Number += 1;
                items = dbContext.WatchItem.GetPagedList(page);
                UpdateData(items, dbContext);
            }
            dbContext.SaveChanges();
            dbContext.ChangeTracker.Clear();
        }

        private void UpdateData(PagedList<WatchItem> items, WatchCinemaDbContext dbContext)
        {
            foreach (var item in items)
            {
                item.TitleNormalized = item.Title.ToLower();
            }
            dbContext.WatchItem.UpdateRange(items);
        }
    }
}
