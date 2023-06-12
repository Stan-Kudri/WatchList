using Microsoft.EntityFrameworkCore;
using WatchList.Core.Model.ItemCinema;
using WatchList.Core.Repository.Extension;

namespace WatchList.Core.Repository.Db
{
    public class WatchCinemaDbContext : DbContext
    {
        public WatchCinemaDbContext(DbContextOptions options)
            : base(options)
        {
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
