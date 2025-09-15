using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Commands.TarefasCategorias.Desvincular
{
    public class DesvincularTarefaCateogiraCommandHandler : CommandHandler, IRequestHandler<DesvincularTarefaCateogiraCommand, ValidationResult>
    {
        private readonly ITarefaRepository _trefaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public DesvincularTarefaCateogiraCommandHandler(ITarefaRepository trefaRepository, ICategoriaRepository categoriaRepository)
        {
            _trefaRepository = trefaRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<ValidationResult> Handle(DesvincularTarefaCateogiraCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _trefaRepository.GetById(request.IdTarefa);
            if (tarefa is null)
            {
                AddError("Tarefa não encontrada.");
                return ValidationResult;
            }

            var categoria = await _categoriaRepository.GetById(request.IdCategoria);
            if (categoria is null)
            {
                AddError("Categoria não encontrada");
                return ValidationResult;
            }

            tarefa.DisvincularCategoria(categoria);

            return await PersistData(_trefaRepository.UnitOfWork);
        }
    }
}
