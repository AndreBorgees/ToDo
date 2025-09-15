using Core.Messages;
using FluentValidation.Results;
using MediatR;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Application.Commands.TarefasCategorias.Vincular
{
    public class VincularTarefaCateogiraCommandHandler : CommandHandler, IRequestHandler<VincularTarefaCateogiraCommand, ValidationResult>
    {
        private readonly ITarefaRepository _trefaRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public VincularTarefaCateogiraCommandHandler(ITarefaRepository trefaRepository, ICategoriaRepository categoriaRepository)
        {
            _trefaRepository = trefaRepository;
            _categoriaRepository = categoriaRepository;           
        }

        public async Task<ValidationResult> Handle(VincularTarefaCateogiraCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _trefaRepository.GetById(request.IdTarefa);
            if (tarefa is null) 
            {
                AddError("Tarefa não encontrada.");
                return ValidationResult;
            }

            var categoria = await _categoriaRepository.GetById(request.IdCategoria);
            if(categoria is null)
            {
                AddError("Categoria não encontrada");
                return ValidationResult;
            }

            tarefa.VincularCategoria(categoria);


            return await PersistData(_trefaRepository.UnitOfWork);
        }
    }
}
