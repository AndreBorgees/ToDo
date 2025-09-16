using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Commands.Tarefas.Atualizar
{
    public class AtualizarTarefaCommandHandler : CommandHandler, IRequestHandler<AtualizarTarefaCommand, ValidationResult>
    {
        private readonly ITarefaRepository _trefaRepository;

        public AtualizarTarefaCommandHandler(ITarefaRepository trefaRepository)
        {
            _trefaRepository = trefaRepository;
        }

        public async Task<ValidationResult> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return ValidationResult;

            var tarefa = await _trefaRepository.GetById(request.Id);
            if(tarefa is null)
            {
                AddError("Tarefa não encontrada.");
                return ValidationResult;
            }

            tarefa.Atualizar(request.Titulo, 
                request.Descricao, 
                request.DataCriacao,
                request.DataConclusao,
                request.Status,
                request.Prioridade);

            _trefaRepository.Update(tarefa);

            return await PersistData(_trefaRepository.UnitOfWork);
        }
    }
}
