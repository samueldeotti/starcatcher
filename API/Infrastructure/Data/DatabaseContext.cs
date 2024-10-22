using Microsoft.EntityFrameworkCore;
using Starcatcher.Domain.Entities;

namespace Starcatcher.Infrastructure.Data
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Consortium> Consortia { get; set; }
        public DbSet<Quota> Quotas { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        // -------------------------------
        // fazer o mapeamento das entidades
        // -------------------------------


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedConsortiums(modelBuilder);
        }

        private static void SeedConsortiums(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consortium>().HasData(
            new Consortium
            {
                ConsortiumId = 1,
                Name = "Consórcio de Carros",
                Description = "Consórcio para aquisição de veículos",
                CreatedAt = DateTime.Now
            },
            new Consortium
            {
                ConsortiumId = 2,
                Name = "Consórcio de Imóveis",
                Description = "Consórcio para aquisição de imóveis",
                CreatedAt = DateTime.Now
            },
            new Consortium
            {
                ConsortiumId = 3,
                Name = "Consórcio de Motos",
                Description = "Consórcio para aquisição de motocicletas",
                CreatedAt = DateTime.Now
            }
            );
        }
    }
}