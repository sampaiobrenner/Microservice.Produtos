using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;
using Microservice.Produtos.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Produtos.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoServices _produtoServices;

        public ProdutoController(IProdutoServices produtoServices) => _produtoServices = produtoServices;

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!await _produtoServices.ExistsAsync(id, cancellationToken)) return NotFound();

            await _produtoServices.DeleteAsync(id, cancellationToken);
            return Accepted();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var produtos = await _produtoServices.GetAllAsync(cancellationToken);
            if (produtos is { Count: 0 }) return NoContent();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");

            var produto = await _produtoServices.GetByIdAsync(id, cancellationToken);
            if (produto is null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoModel model, CancellationToken cancellationToken)
        {
            var produto = await _produtoServices.SaveAsync(model, cancellationToken);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = produto.Id, cancellationToken, version = HttpContext.GetRequestedApiVersion().ToString() },
                produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ProdutoModel model, CancellationToken cancellationToken)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");
            if (model?.Id != id) return BadRequest("Identificador diverge do objeto solicitado.");

            var produto = await _produtoServices.EditAsync(model, cancellationToken);
            return Ok(produto);
        }
    }
}