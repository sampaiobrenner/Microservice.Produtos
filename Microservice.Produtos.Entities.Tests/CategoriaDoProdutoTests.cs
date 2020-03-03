using Microservice.Produtos.Entities.Entities.Builders;
using System;
using Xunit;

namespace Microservice.Produtos.Entities.UnitTests
{
    public class CategoriaDoProdutoTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CriarNovaCategoriaDoProdutoComErro(string nome)
        {
            var produto = new CategoriaDoProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome(nome)
                .Build();

            Assert.False(produto.IsValid);
        }

        [Fact]
        public void CriarNovaCategoriaDoProdutoSemErro()
        {
            var produto = new CategoriaDoProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome("Produto teste")
                .Build();

            Assert.True(produto.IsValid);
        }
    }
}