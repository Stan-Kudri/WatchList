using WatchList.Core.Repository.Db;

namespace WatchList.Migrations.SQLite.Interceptors
{
    internal interface IMigrationInterceptor
    {
        void Intercept(WatchCinemaDbContext dbContext);
    }
}
