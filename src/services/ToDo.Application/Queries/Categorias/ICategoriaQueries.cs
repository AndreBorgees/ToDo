using ToDo.Application.DTOs;

namespace ToDo.Application.Queries.Categorias
{
    public interface ICategoriaQueries
    {
        Task<CategoriaDTO> BuscarCategoriaPorIdAsync(Guid id);
        Task<IEnumerable<CategoriaDTO>> BuscarTodasCategoriasAsync();
    }
}
