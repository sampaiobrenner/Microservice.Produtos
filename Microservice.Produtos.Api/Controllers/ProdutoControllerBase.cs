using Microsoft.AspNetCore.Mvc;

namespace Microservice.Produtos.WebApi.Controllers
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public class ProdutoControllerBase : ControllerBase
    {
    }
}