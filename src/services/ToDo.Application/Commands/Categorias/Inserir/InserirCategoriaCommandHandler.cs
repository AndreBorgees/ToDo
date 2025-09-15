using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Categorias;

namespace ToDo.Application.Commands.Categorias.Inserir
{
    public class InserirCategoriaCommandHandler : CommandHandler, IRequestHandler<InserirCategoriaCommand, ValidationResult>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public InserirCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;                
        }

        public async Task<ValidationResult> Handle(InserirCategoriaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var categoria = MapeamentoCategoria(request);

            _categoriaRepository.Add(categoria);

            return await PersistData(_categoriaRepository.UnitOfWork);
        }

        private Categoria MapeamentoCategoria(InserirCategoriaCommand command)
        {
            return new Categoria(command.Nome, command.Cor);
        }
    }
}
