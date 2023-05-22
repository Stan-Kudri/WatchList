using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.DbContext;

namespace WatchList.WinForms.DbContext
{
    public sealed class FileDbContextFactory : IDbContextFactory
    {
        public string _path;

        public FileDbContextFactory(string path) => _path = path;

        public WatchCinemaDbContext Create()
        {
            var builder = new DbContextOptionsBuilder().UseSqlite($"Data Source={_path}");
            return new WatchCinemaDbContext(builder.Options);
        }
    }
}
