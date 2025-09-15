using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Commands.Tarefas.Excluir
{
    public class ExcluirTarefaCommandHandler : CommandHandler, IRequestHandler<ExcluirTarefaCommand, ValidationResult>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ExcluirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<ValidationResult> Handle(ExcluirTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return ValidationResult;

            var tarefa = await _tarefaRepository.GetById(request.Id);
            if (tarefa is null)
            {
                AddError("Categoria não encontrada.");
                return ValidationResult;
            }

            _tarefaRepository.Delete(tarefa);

            return await PersistData(_tarefaRepository.UnitOfWork);
        }
    }
}
