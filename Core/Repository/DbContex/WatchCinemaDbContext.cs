using System.Text.Json;
using ListWatchedMoviesAndSeries.Models;
using ListWatchedMoviesAndSeries.Models.Item;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.DbContex
{
    public class WatchCinemaDbContext : DbContext
    {
        public DbSet<WatchItem> WatchItem { get; set; } = null!;

        public WatchCinemaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchItem>(buildAction =>
            {
                buildAction.HasKey(x => x.Id);
                buildAction.Property(x => x.Name).HasMaxLength(50).IsRequired();
                buildAction.Property(x => x.Id).ValueGeneratedOnAdd();
                buildAction.Property(x => x.Detail).HasConversion(
                    x => JsonSerializer.Serialize(x, (JsonSerializerOptions?)null),
                    json => JsonSerializer.Deserialize<WatchDetail>(json, (JsonSerializerOptions?)null) ?? new WatchDetail());
                buildAction.Property(x => x.Type).SmartEnumConversion();
                buildAction.Property(x => x.Status).SmartEnumConversion();
            });
        }
    }
}
