using Microservice.Produtos.Entities.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Produtos.Repositories.Configs
{
    public class CategoriaDoProdutoConfig : IEntityTypeConfiguration<CategoriaDoProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaDoProduto> builder)
        {
            builder.ToTable(nameof(CategoriaDoProduto));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome");
        }
    }
}