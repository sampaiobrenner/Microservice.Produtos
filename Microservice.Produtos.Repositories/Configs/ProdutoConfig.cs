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
        }
    }
}