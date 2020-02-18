using Microservice.Produtos.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Produtos.Repositories.Contexts
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}