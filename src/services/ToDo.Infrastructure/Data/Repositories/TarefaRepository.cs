using Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ToDo.Domain.Entities.Tarefas;
using ToDo.Infrastructure.Data.Context;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DataContext _context;

        public TarefaRepository(DataContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();

        public void Add(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
        }

        public void Update(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }

        public void Delete(Tarefa tarefa)
        {
            _context.Tarefas.Remove(tarefa);
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tarefas
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Tarefa?> GetById(Guid id)
        {
            return await _context.Tarefas
                .Include(t => t.Categorias)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
