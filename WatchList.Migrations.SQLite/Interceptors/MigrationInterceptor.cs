using WatchList.Core.Repository.Db;

namespace WatchList.Migrations.SQLite.Interceptors
{
    public class MigrationInterceptor
    {
        private static readonly Dictionary<string, IMigrationInterceptor> _interceptorsMap = Create();

        private readonly WatchCinemaDbContext _db;

        public MigrationInterceptor(WatchCinemaDbContext db)
        {
            _db = db;
        }

        public void Intercept(string migration)
        {
            if (_interceptorsMap.TryGetValue(migration, out var interceptor))
            {
                interceptor.Intercept(_db);
            }
        }

        private static Dictionary<string, IMigrationInterceptor> Create()
        {
            var result = new Dictionary<string, IMigrationInterceptor>();
            result.Add("20230722060853_WatchItem_Add_TitleNormalized", new WatchItem_Add_TitleNormalized_Interceptor());
            return result;
        }
    }
}
