using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Categorias;

namespace ToDo.Application.Commands.Categorias.Atualizar
{
    public class AtualizarCategoriaCommandHandler : CommandHandler, IRequestHandler<AtualizarCategoriaCommand, ValidationResult>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public AtualizarCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;         
        }

        public async Task<ValidationResult> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var categoria = await _categoriaRepository.GetById(request.IdCategoria);
            if (categoria is null)
            {
                AddError("Categoria não encontrada.");
                return ValidationResult;
            }

            categoria.Atualizar(request.Nome, request.Cor);

            _categoriaRepository.Update(categoria);

            return await PersistData(_categoriaRepository.UnitOfWork);
        }
    }
}
