using Core.Data;
using System.Data.Common;

namespace ToDo.Domain.Entities.Tarefas
{
    public interface ITarefaRepository: IRepository<Tarefa>
    {
        Task<Tarefa?> GetById(Guid id);
        Task<IEnumerable<Tarefa>> GetAll();
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);
        DbConnection GetConnection();
    }
}
