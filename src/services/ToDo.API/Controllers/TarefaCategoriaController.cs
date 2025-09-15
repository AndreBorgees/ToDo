using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Application.Commands.TarefasCategorias.Desvincular;
using ToDo.Application.Commands.TarefasCategorias.Vincular;
using WebAPI.Core.Controllers;

namespace ToDo.API.Controllers
{
    public class TarefaCategoriaController : BaseController
    {
        private readonly IMediatorHandler _mediator;

        public TarefaCategoriaController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("tarefas-categorias")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> InserirCategoria([FromBody] VincularTarefaCateogiraCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return CustomResponse(result);
        }

        [HttpDelete("tarefas-categorias")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> InserirCategoria([FromBody] DesvincularTarefaCateogiraCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return CustomResponse(result);
        }
    }
}
