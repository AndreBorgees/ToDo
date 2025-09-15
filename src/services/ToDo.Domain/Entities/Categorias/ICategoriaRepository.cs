using Core.Data;
using System.Data.Common;

namespace ToDo.Domain.Entities.Categorias
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        Task<Categoria?> GetById(Guid id);
        Task<IEnumerable<Categoria>> GetAll();
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        DbConnection GetConnection();
    }
}
