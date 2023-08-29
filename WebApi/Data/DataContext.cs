using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        
        public DbSet<Enfant> Enfants { get; set; }
        public DbSet<Famille> Familles { get; set; }
        public DbSet<Parrain> Parrains { get; set; }
        public DbSet<Parrainage> Parrainages { get; set; }
        public DbSet<Admin> Admin { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parrainage>()
                .HasKey(p => new { p.EnfantId, p.ParrainId });

            modelBuilder.Entity<Parrainage>()
                .HasOne(p => p.Enfant)
                .WithMany(pc => pc.Parrainages)
                .HasForeignKey(p => p.EnfantId);
            modelBuilder.Entity<Parrainage>()
                .HasOne(p => p.Parrain)
                .WithMany(pc => pc.Parrainages)
                .HasForeignKey(c => c.ParrainId);

            modelBuilder.Entity<Admin>();
        }

    }

}
