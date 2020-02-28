using GraphQL.Types;
using Microservice.Produtos.Repositories.Contexts;
using Microservice.Produtos.WebApi.Types;
using System.Linq;

namespace Microservice.Produtos.WebApi.Queries
{
    public class ProdutoQuery : ObjectGraphType
    {
        public ProdutoQuery(ApplicationDbContext db)
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

                  var query = db.Produtos.AsQueryable();

                  if (!string.IsNullOrEmpty(filtroNome))
                      query = query.Where(x => x.Nome == filtroNome);

                  return query.ToList();
              }
              );
        }
    }
}