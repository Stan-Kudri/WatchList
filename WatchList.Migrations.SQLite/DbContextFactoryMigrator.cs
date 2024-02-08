using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.Db;

namespace WatchList.Migrations.SQLite
{
    public sealed class DbContextFactoryMigrator
    {
        public string _path;

        public DbContextFactoryMigrator(string path) => _path = path;

        public WatchCinemaDbContext Create()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source={_path}", x =>
            {
                x.MigrationsAssembly(typeof(DbContextFactory).Assembly.FullName);
            });

            var dbContext = new WatchCinemaDbContext(builder.Options);
            dbContext.Migrate();

            return dbContext;
        }
    }
}
