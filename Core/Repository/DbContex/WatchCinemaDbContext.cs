using Core.Model.ItemCinema;
using Core.Repository.Extension;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.DbContex
{
    public class WatchCinemaDbContext : DbContext
    {
        public WatchCinemaDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WatchItem> WatchItem { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchItem>(buildAction =>
            {
                buildAction.HasKey(x => x.Id);
                buildAction.Property(x => x.Title).HasMaxLength(50).IsRequired();
                buildAction.Property(x => x.Id).ValueGeneratedOnAdd();
                buildAction.Property(x => x.Sequel).HasColumnType("INTEGER").IsRequired();
                buildAction.Property(x => x.Date).HasColumnType("DATETIME");
                buildAction.Property(x => x.Grade).HasColumnType("INTEGER");
                buildAction.Property(x => x.Type).SmartEnumConversion();
                buildAction.Property(x => x.Status).SmartEnumConversion();
            });
        }
    }
}
