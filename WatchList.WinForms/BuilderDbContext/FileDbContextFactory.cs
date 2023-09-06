using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.Db;
using WatchList.Migrations.SQLite;

namespace WatchList.WinForms.BuilderDbContext
{
    public sealed class FileDbContextFactory
    {
        public string _path;

        public FileDbContextFactory(string path) => _path = path;

        public WatchCinemaDbContext Create()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source={_path}", x =>
            {
                x.MigrationsAssembly(typeof(DbContextFactory).Assembly.FullName);
            });

            return new WatchCinemaDbContext(builder.Options);
        }
    }
}
