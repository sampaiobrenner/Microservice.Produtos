using Microsoft.AspNetCore.Mvc;

namespace Microservice.Produtos.WebApi.Controllers.Base
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}