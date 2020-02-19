using Microservice.Produtos.Services.Interfaces;
using Microservice.Produtos.Services.Models;
using Microservice.Produtos.WebApi.Controllers.Base;
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
            var produtos = _produtoServices.GetAll();
            if (produtos is { Count: 0 }) return NoContent();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");

            var produto = _produtoServices.GetById(id);
            if (produto is null) return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoModel model)
        {
            var produto = _produtoServices.Save(model);

            return CreatedAtAction(nameof(GetById),
                new { id = produto.Id, version = HttpContext.GetRequestedApiVersion().ToString() },
                produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoModel model)
        {
            if (Guid.Empty == id) return BadRequest("Identificador inválido.");
            if (model?.Id != id) return BadRequest("Identificador diverge do objeto solicitado.");

            var produto = _produtoServices.Edit(model);
            return Ok(produto);
        }
    }
}