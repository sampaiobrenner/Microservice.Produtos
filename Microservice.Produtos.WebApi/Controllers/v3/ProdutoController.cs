using GraphQL;
using GraphQL.Types;
using Microservice.Produtos.Repositories.Contexts;
using Microservice.Produtos.WebApi.Controllers.Base;
using Microservice.Produtos.WebApi.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservice.Produtos.WebApi.Controllers.v3
{
    [ApiVersion("3")]
    public class ProdutoController : BaseController
    {
        private readonly ApplicationDbContext _db;

        public ProdutoController(ApplicationDbContext db) => _db = db;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new ProdutoQuery(_db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(options =>
            {
                options.Schema = schema;
                options.Query = query.Query;
                options.OperationName = query.OperationName;
                options.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
                return BadRequest(result);

            return Ok(result);
        }
    }
}