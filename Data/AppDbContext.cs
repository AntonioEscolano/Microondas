using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Microondas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entities here if needed
        }


        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set;
        public DbSet<Microondas.Models.ProgramacaoModel> Programacao { get; set; }

    }
}
