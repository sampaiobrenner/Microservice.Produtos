using GraphQL;
using Microservice.Produtos.WebApi.Controllers.Base;
using Microservice.Produtos.WebApi.GraphQL.GraphQLQueries;
using Microservice.Produtos.WebApi.GraphQL.GraphQLSchema;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservice.Produtos.WebApi.Controllers.v3
{
    [ApiVersion("3")]
    public class ProdutoController : BaseController
    {
        private readonly ProdutoSchema _produtoSchema;

        public ProdutoController(ProdutoSchema produtoSchema) => _produtoSchema = produtoSchema;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = _produtoSchema;
                options.Query = query.Query;
                options.OperationName = query.OperationName;
                options.Inputs = inputs;
            }).ConfigureAwait(false);

            return TratarRetorno(result);
        }
    }
}