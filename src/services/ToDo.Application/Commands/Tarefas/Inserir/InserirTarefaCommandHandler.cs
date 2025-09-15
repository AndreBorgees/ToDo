using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Commands.Tarefas.Inserir
{
    public class InserirTarefaCommandHandler : CommandHandler, IRequestHandler<InserirTarefaCommand, ValidationResult>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public InserirTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;          
        }

        public async Task<ValidationResult> Handle(InserirTarefaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return ValidationResult;

            var tarefa = MapameamentoTarefa(request);

            _tarefaRepository.Add(tarefa);

            return await PersistData(_tarefaRepository.UnitOfWork);
        }

        private Tarefa MapameamentoTarefa(InserirTarefaCommand request)
        {
            return new Tarefa(
                request.Titulo,
                request.Descricao,
                request.DataCriacao,
                request.DataConclusao,
                request.Status,
                request.Prioridade);
        }
    }
}
