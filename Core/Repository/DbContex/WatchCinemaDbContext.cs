using Core.Repository.Extension;
using ListWatchedMoviesAndSeries.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.DbContex
{
    public class WatchCinemaDbContext : DbContext
    {
        public DbSet<WatchItem> WatchItem { get; set; } = null!;

        public WatchCinemaDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchItem>(buildAction =>
            {
                buildAction.HasKey(x => x.Id);
                buildAction.Property(x => x.Name).HasMaxLength(50).IsRequired();
                buildAction.Property(x => x.Id).ValueGeneratedOnAdd();
                buildAction.Property(x => x.NumberSequel).HasColumnType("INTEGER").IsRequired();
                buildAction.Property(x => x.Date).HasColumnType("DATETIME");
                buildAction.Property(x => x.Grade).HasColumnType("INTEGER");
                buildAction.Property(x => x.Type).SmartEnumConversion();
                buildAction.Property(x => x.Status).SmartEnumConversion();
            });
        }
    }
}
