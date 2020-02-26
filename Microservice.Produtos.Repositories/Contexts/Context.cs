using Microservice.Produtos.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Produtos.Repositories.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CategoriaDoProduto> CategoriaDosProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}