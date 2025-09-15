using Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ToDo.Domain.Entities.Categorias;
using ToDo.Infrastructure.Data.Context;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;             
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria); 
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(Guid id)
        {
            return await _context.Categorias.FindAsync(id);    
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
