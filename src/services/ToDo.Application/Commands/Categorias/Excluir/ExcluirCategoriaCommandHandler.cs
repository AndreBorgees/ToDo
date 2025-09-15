using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Categorias;

namespace ToDo.Application.Commands.Categorias.Excluir
{
    public class ExcluirCategoriaCommandHandler : CommandHandler, IRequestHandler<ExcluirCategoriaCommand, ValidationResult>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public ExcluirCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;        
        }

        public async Task<ValidationResult> Handle(ExcluirCategoriaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult; 

            var categoria = await _categoriaRepository.GetById(request.Id);
            if (categoria is null)
            {
                AddError("Categoria não encontrada.");
                return ValidationResult;
            }

            _categoriaRepository.Delete(categoria);

            return await PersistData(_categoriaRepository.UnitOfWork);
        }
    }
}
