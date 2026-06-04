using IncidentLog.Models;
using Microsoft.EntityFrameworkCore;

namespace IncidentLog.Data;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Incident> Incidents { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Evidence> Evidences { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints if needed
            modelBuilder.Entity<User>()
                .HasMany(u => u.Incidents)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Incident>()
                .HasMany(i => i.Comments)
                .WithOne(c => c.Incident)
                .HasForeignKey(c => c.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Incident>()
                .HasMany(i => i.Evidence)
                .WithOne(e => e.Incident)
                .HasForeignKey(e => e.IncidentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
