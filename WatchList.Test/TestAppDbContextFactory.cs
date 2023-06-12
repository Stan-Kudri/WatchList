using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repository.DbContext;

namespace WatchList.Test
{
    public class TestAppDbContextFactory
    {
        public WatchCinemaDbContext Create()
        {
            var sqlLiteConnection = new SqliteConnection("Data Source=:memory:");
            sqlLiteConnection.Open();

            var option = new DbContextOptionsBuilder().UseSqlite(sqlLiteConnection);

            return new WatchCinemaDbContext(option.Options);
        }
    }
}
