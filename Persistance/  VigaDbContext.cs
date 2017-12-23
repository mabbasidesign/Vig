using Microsoft.EntityFrameworkCore;
using Vig.Models;

namespace Vig.Persistance
{
    public class VigaDbContext : DbContext
    {
        // public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features {get; set;}

        public VigaDbContext(DbContextOptions<VigaDbContext> options)
            :base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
            new {vf.VehicleId, vf.FeatureId});
        }

    }
}