using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using WatchList.Core.Repository.Db;
using WatchList.Migrations.SQLite.Interceptors;

namespace WatchList.Migrations.SQLite
{
    public static class DbMigrator
    {
        public static void Migrate(this WatchCinemaDbContext db)
        {
            var interceptor = new MigrationInterceptor(db);

            var migrate = db.Database.GetInfrastructure().GetService<IMigrator>()
                ?? throw new InvalidOperationException("Unable to found migrator service.");

            foreach (var migrationName in db.Database.GetPendingMigrations())
            {
                migrate.Migrate(migrationName);
                interceptor.Intercept(migrationName);
            }
        }
    }
}
