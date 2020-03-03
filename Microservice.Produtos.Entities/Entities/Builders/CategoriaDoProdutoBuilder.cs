using Microservice.Produtos.Entities.Base;

namespace Microservice.Produtos.Entities.Entities.Builders
{
    public class CategoriaDoProdutoBuilder : BuilderBase<CategoriaDoProdutoBuilder, CategoriaDoProduto>
    {
        private string Nome { get; set; }

        public override CategoriaDoProduto Build() => CategoriaDoProduto.CreateInstance(Id, Nome);

        public CategoriaDoProdutoBuilder WithNome(string nome)
        {
            Nome = nome;
            return this;
        }
    }
}