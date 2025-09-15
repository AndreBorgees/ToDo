using ToDo.Application.DTOs;
using ToDo.Domain.Entities.Categorias;

namespace ToDo.Application.Queries.Categorias
{
    public class CategoriaQueries : ICategoriaQueries
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaQueries(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;       
        }

        public async Task<CategoriaDTO> BuscarCategoriaPorIdAsync(Guid id)
        {
            var categoria = await _categoriaRepository.GetById(id);

            if (categoria is null) return null;

            return new CategoriaDTO
            { 
                Id = categoria.Id,
                Nome = categoria.Nome,
                Cor = categoria.Cor
            };
        }

        public async Task<IEnumerable<CategoriaDTO>> BuscarTodasCategoriasAsync()
        {
            var categorias = await _categoriaRepository.GetAll();

            return categorias.Select(categoria => new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Cor = categoria.Cor,
            });
        }
    }
}
