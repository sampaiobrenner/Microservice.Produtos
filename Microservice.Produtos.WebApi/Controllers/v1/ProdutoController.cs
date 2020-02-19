using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Microservice.Produtos.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class ProdutoController : ProdutoControllerBase
    {
        private readonly IProdutoServices _produtoServices;

        public ProdutoController(IProdutoServices produtoServices) => _produtoServices = produtoServices;

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_produtoServices.Exists(id)) return NotFound();

            _produtoServices.Delete(id);
            return Accepted();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoModel>> GetAll()
        {
            var whatevers = _produtoServices.GetAll();
            if (whatevers is { Count: 0 }) return NoContent();

            return Ok(whatevers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");

            var whatever = _produtoServices.GetById(id);
            if (whatever is null) return NotFound();

            return Ok(whatever);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoModel model)
        {
            var whatever = _produtoServices.Save(model);

            return CreatedAtAction(nameof(GetById),
                new { id = whatever.Id, version = HttpContext.GetRequestedApiVersion().ToString() },
                whatever);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoModel model)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");
            if (model?.Id != id) return BadRequest("Identificador diverge do objeto solicitado.");

            var whatever = _produtoServices.Edit(model);
            return Ok(whatever);
        }
    }
}