using DoneDay.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoneDay.Infrastructure.Data
{
    public class DoneDayDbContext : DbContext
    {
        public DoneDayDbContext(DbContextOptions<DoneDayDbContext> options)
            : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; }  // Habits tablosu

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
} 