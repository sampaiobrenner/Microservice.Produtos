using GraphQL.Types;
using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.WebApi.GraphQL.GraphQLTypes;

namespace Microservice.Produtos.WebApi.GraphQL.GraphQLQueries
{
    public class ProdutoQuery : ObjectGraphType
    {
        public ProdutoQuery(IProdutoServices produtoServices)
        {
            Field<ListGraphType<ProdutoType>>("produto",
              arguments: new QueryArguments(new QueryArgument[]
              {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="nome"}
              }),
              resolve: contexto =>
              {
                  var filtroNome = contexto.GetArgument<string>("nome");

                  return produtoServices.GetAll();
              }
              );
        }
    }
}