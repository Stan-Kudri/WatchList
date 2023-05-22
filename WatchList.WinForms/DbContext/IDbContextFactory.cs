using WatchList.Core.Repository.DbContext;

namespace WatchList.WinForms.DbContext
{
    public interface IDbContextFactory
    {
        WatchCinemaDbContext Create();
    }
}
