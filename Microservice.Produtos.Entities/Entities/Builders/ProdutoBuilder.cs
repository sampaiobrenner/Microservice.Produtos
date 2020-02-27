using Microservice.Produtos.Entities.Base;

namespace Microservice.Produtos.Entities.Entities.Builders
{
    public class ProdutoBuilder : BuilderBase<ProdutoBuilder, Produto>
    {
        private string Nome { get; set; }
        private decimal PrecoDeCusto { get; set; }
        private decimal PrecoDeVenda { get; set; }

        public override Produto Build() => new Produto(Id, Nome, PrecoDeCusto, PrecoDeVenda);

        public ProdutoBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public ProdutoBuilder WithPrecoDeCusto(decimal precoDeCusto)
        {
            PrecoDeCusto = precoDeCusto;
            return this;
        }

        public ProdutoBuilder WithPrecoDeVenda(decimal precoDeVenda)
        {
            PrecoDeVenda = precoDeVenda;
            return this;
        }
    }
}