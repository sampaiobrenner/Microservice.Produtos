using GraphQL;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Produtos.WebApi.Controllers.Base
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult TratarRetorno(ExecutionResult result) =>
            result.Errors?.Count > 0
                ? BadRequest(result)
                : (IActionResult)Ok(result);
    }
}