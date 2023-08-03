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

        public override int SaveChanges()
        {
            UpdateTitleNormalized();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTitleNormalized();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WatchItem>(buildAction =>
            {
                buildAction.HasKey(x => x.Id);
                buildAction.Property(x => x.Title).HasMaxLength(50).IsRequired();
                buildAction.Property(x => x.TitleNormalized).HasMaxLength(50).IsRequired().HasDefaultValue(string.Empty);
                buildAction.Property(x => x.Id).ValueGeneratedOnAdd();
                buildAction.Property(x => x.Sequel).HasColumnType("INTEGER").IsRequired();
                buildAction.Property(x => x.Date).HasColumnType("DATETIME");
                buildAction.Property(x => x.Grade).HasColumnType("INTEGER");
                buildAction.Property(x => x.Type).SmartEnumConversion();
                buildAction.Property(x => x.Status).SmartEnumConversion();
                buildAction.HasIndex(x => x.TitleNormalized);
            });
        }

        private void UpdateTitleNormalized()
        {
            var changedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).Select(x => x.Entity).OfType<WatchItem>();
            foreach (var changeEntry in changedEntries)
            {
                changeEntry.TitleNormalized = changeEntry.Title.ToLower();
            }
        }
    }
}
