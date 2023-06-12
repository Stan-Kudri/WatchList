using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.Db;

namespace WatchList.WinForms.BuilderDbContext
{
    public sealed class FileDbContextFactory
    {
        public string _path = "app.db";

        public FileDbContextFactory(string path) => _path = path;

        public WatchCinemaDbContext Create()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source={_path}");
            var dbContext = new WatchCinemaDbContext(builder.Options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
