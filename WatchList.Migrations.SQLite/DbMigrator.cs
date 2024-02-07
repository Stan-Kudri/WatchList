using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Repository.Db;
using WatchList.Migrations.SQLite.Interceptors;

namespace WatchList.Migrations.SQLite
{
    public class DbMigrator
    {
        private readonly WatchCinemaDbContext _db;

        public DbMigrator(WatchCinemaDbContext db) => _db = db;

        public void Migrate()
        {
            var interceptor = new MigrationInterceptor(_db);

            var migrate = _db.Database.GetInfrastructure().GetService<IMigrator>()
                ?? throw new InvalidOperationException("Unable to found migrator service.");

            foreach (var migrationName in _db.Database.GetPendingMigrations())
            {
                migrate.Migrate(migrationName);
                interceptor.Intercept(migrationName);
            }
        }
    }
}
