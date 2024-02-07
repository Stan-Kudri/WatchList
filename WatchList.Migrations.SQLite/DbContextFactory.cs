using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WatchList.Core.Repository.Db;

namespace WatchList.Migrations.SQLite
{
    public class DbContextFactory : IDesignTimeDbContextFactory<WatchCinemaDbContext>
    {
        public WatchCinemaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder().UseSqlite(
                $"Data Source=app.db",
                b => b.MigrationsAssembly(typeof(DbContextFactory).Assembly.FullName));

            return new WatchCinemaDbContext(builder.Options);
        }
    }
}
