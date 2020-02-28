using Microservice.Produtos.Entities.Entities.Builders;
using System;
using Xunit;

namespace Microservice.Produtos.Entities.Tests
{
    public class ProdutoTests
    {
        [Theory]
        [InlineData("", 10.50, 12.0)]
        [InlineData(null, 0.01, 100.00)]
        [InlineData("Teste com valor de custo zerado", 0.00, 100.00)]
        [InlineData("Teste com valor de venda zerado", 10.00, 0.00)]
        public void CriarNovoProdutoComErro(string nome, decimal precoDeCusto,
            decimal precoDeVenda)
        {
            var produto = new ProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome(nome)
                .WithPrecoDeCusto(precoDeCusto)
                .WithPrecoDeVenda(precoDeVenda)
                .Build();

            Assert.False(produto.IsValid);
        }

        [Theory]
        [InlineData("Produto teste", 10.50, 12.0)]
        [InlineData("Produto teste 2", 0.01, 100.00)]
        public void CriarNovoProdutoSemErro(string nome, decimal precoDeCusto,
            decimal precoDeVenda)
        {
            var produto = new ProdutoBuilder()
                .WithId(Guid.NewGuid())
                .WithNome(nome)
                .WithPrecoDeCusto(precoDeCusto)
                .WithPrecoDeVenda(precoDeVenda)
                .Build();

            Assert.True(produto.IsValid);
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(precoDeCusto, produto.PrecoDeCusto);
            Assert.Equal(precoDeVenda, produto.PrecoDeVenda);
        }
    }
}