using Microservice.Produtos.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Produtos.Repositories.Configs
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(c => c.PrecoDeCusto).IsRequired().HasColumnType("decimal(5,3)").HasColumnName("PrecoDeCusto");
            builder.Property(c => c.PrecoDeVenda).IsRequired().HasColumnType("decimal(5,3)").HasColumnName("PrecoDeVenda");

            builder.HasOne(c => c.CategoriaDoProduto);
        }
    }
}