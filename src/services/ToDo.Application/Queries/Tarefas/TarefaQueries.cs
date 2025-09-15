using ToDo.Application.DTOs;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Queries.Tarefas
{
    public class TarefaQueries : ITarefaQueries
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaQueries(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaDTO> BuscarTarefaPorIdAsync(Guid id)
        {
            var tarefa = await _tarefaRepository.GetById(id);

            if (tarefa is null) return null;

            return new TarefaDTO
            {
                Id = tarefa.Id,
                Descricao = tarefa.Descricao,
                DataConclusao = tarefa.DataConclusao,
                DataCriacao = tarefa.DataCriacao,
                Prioridade = tarefa.Prioridade,
                Status = tarefa.Status
            };
        }

        public async Task<IEnumerable<TarefaDTO>> BuscarTodasTarefasAsync()
        {
            var tarefas = await _tarefaRepository.GetAll();

            if (!tarefas.Any()) return null;

            return tarefas.Select(tarefa => new TarefaDTO
            {
                Id = tarefa.Id,
                Descricao = tarefa.Descricao,
                DataConclusao = tarefa.DataConclusao,
                DataCriacao = tarefa.DataCriacao,
                Prioridade = tarefa.Prioridade,
                Status = tarefa.Status
            });
        }
    }
}
