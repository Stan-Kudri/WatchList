using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.Db;

namespace WatchList.Test.Components
{
    public class TestAppDbContextFactory
    {
        public WatchCinemaDbContext Create()
        {
            var sqlLiteConnection = new SqliteConnection("Data Source=:memory:");
            sqlLiteConnection.Open();
            var builder = new DbContextOptionsBuilder().UseSqlite(sqlLiteConnection);
            var dbContext = new WatchCinemaDbContext(builder.Options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
