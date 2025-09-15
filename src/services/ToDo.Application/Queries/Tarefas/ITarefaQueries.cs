using ToDo.Application.DTOs;

namespace ToDo.Application.Queries.Tarefas
{
    public interface ITarefaQueries
    {
        Task<TarefaDTO> BuscarTarefaPorIdAsync(Guid id);
        Task<IEnumerable<TarefaDTO>> BuscarTodasTarefasAsync();
    }
}
