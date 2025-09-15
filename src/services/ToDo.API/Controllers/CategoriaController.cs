using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Application.Commands.Categorias.Atualizar;
using ToDo.Application.Commands.Categorias.Excluir;
using ToDo.Application.Commands.Categorias.Inserir;
using ToDo.Application.DTOs;
using ToDo.Application.Queries.Categorias;
using WebAPI.Core.Controllers;

namespace ToDo.API.Controllers
{
    [ApiController]
    public class CategoriaController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly ICategoriaQueries _categoriaQueries;

        public CategoriaController(IMediatorHandler mediator, ICategoriaQueries categoriaQueries)
        {
            _mediator = mediator;
            _categoriaQueries = categoriaQueries;
        }

        [HttpPost("categorias")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> InserirCategoria([FromBody] InserirCategoriaCommand categoriaCommand)
        {
            var result = await _mediator.SendCommand(categoriaCommand);

            return CustomResponse(result);
        }

        [HttpPut("categorias")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AtualizarCategoria([FromBody] AtualizarCategoriaCommand categoriaCommand)
        {
            var result = await _mediator.SendCommand(categoriaCommand);

            return CustomResponse(result);
        }

        [HttpDelete("categorias/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ExcluirCategoria([FromRoute] Guid id)
        {
            var categoriaCommand = new ExcluirCategoriaCommand { Id = id };
            var result = await _mediator.SendCommand(categoriaCommand);

            return CustomResponse(result);
        }

        [HttpGet("categorias")]
        [ProducesResponseType(typeof(IEnumerable<CategoriaDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BuscarTodasCategorias()
        {
            var categoria = await _categoriaQueries.BuscarTodasCategoriasAsync();

            return categoria == null ? NotFound() : CustomResponse(categoria);
        }

        [HttpGet("categorias/{id}")]
        [ProducesResponseType(typeof(CategoriaDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BuscarCategoriaPorId([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var categoria = await _categoriaQueries.BuscarCategoriaPorIdAsync(id);

            return categoria == null ? NotFound() : CustomResponse(categoria);
        }
    }
}
