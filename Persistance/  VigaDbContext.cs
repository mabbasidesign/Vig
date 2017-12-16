using Microsoft.EntityFrameworkCore;
using Vig.Models;

namespace Vig.Persistance
{
    public class   VigaDbContext : DbContext
    {
        public VigaDbContext(DbContextOptions<VigaDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Model> Models { get; set; }
        public DbSet<Make> Makes { get; set; }
    }
}