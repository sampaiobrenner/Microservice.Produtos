using Microservice.Produtos.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace Microservice.Produtos.Repositories.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CategoriaDoProduto> CategoriaDosProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}