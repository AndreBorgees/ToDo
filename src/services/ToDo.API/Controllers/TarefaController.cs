using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDo.Application.Commands.Tarefas.Atualizar;
using ToDo.Application.Commands.Tarefas.Excluir;
using ToDo.Application.Commands.Tarefas.Inserir;
using ToDo.Application.Queries.Tarefas;
using WebAPI.Core.Controllers;

namespace ToDo.API.Controllers
{
    public class TarefaController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly ITarefaQueries _tarefaQuery;

        public TarefaController(IMediatorHandler mediator, ITarefaQueries tarefaQuery)
        {
            _mediator = mediator;
            _tarefaQuery = tarefaQuery;
        }

        [HttpPost("tarefas")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> InserirTarefa([FromBody] InserirTarefaCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return CustomResponse(result);
        }

        [HttpPut("tarefas")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AtualizarTarefa([FromBody] AtualizarTarefaCommand command)
        {
            var result = await _mediator.SendCommand(command);

            return CustomResponse(result);
        }

        [HttpDelete("tarefas/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> ExcuirTarefa(Guid id)
        {
            var command = new ExcluirTarefaCommand() { Id = id };

            var result = await _mediator.SendCommand(command);

            return CustomResponse(result);
        }

        [HttpGet("tarefas/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BuscarTarefaPorId(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var tarefa = await _tarefaQuery.BuscarTarefaPorIdAsync(id);

            return tarefa == null ? NotFound() : CustomResponse(tarefa);
        }

        [HttpGet("tarefas")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BuscarTodasTarefas()
        {
            var tarefa = await _tarefaQuery.BuscarTodasTarefasAsync();

            return tarefa == null ? NotFound() : CustomResponse(tarefa);
        }
    }
}
