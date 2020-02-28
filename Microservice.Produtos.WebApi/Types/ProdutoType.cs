using GraphQL.Types;
using Microservice.Produtos.Entities.Entities;

namespace Microservice.Produtos.WebApi.Types
{
    public class ProdutoType : ObjectGraphType<Produto>
    {
        public ProdutoType()
        {
            Name = "Produto";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id do produto");
            Field(x => x.Nome).Description("Nome do produto");
            Field(x => x.PrecoDeCusto).Description("Preço de custo do produto");
            Field(x => x.PrecoDeVenda).Description("Preço de venda do produto");
        }
    }
}