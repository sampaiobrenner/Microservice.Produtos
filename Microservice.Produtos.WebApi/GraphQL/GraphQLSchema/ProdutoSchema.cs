using GraphQL;
using GraphQL.Types;
using Microservice.Produtos.WebApi.GraphQL.GraphQLQueries;

namespace Microservice.Produtos.WebApi.GraphQL.GraphQLSchema
{
    public class ProdutoSchema : Schema
    {
        public ProdutoSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProdutoQuery>();
        }
    }
}