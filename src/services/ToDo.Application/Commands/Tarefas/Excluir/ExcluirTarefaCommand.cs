using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.Tarefas.Excluir
{
    public class ExcluirTarefaCommand : Command
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ExcluirTarefaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ExcluirTarefaValidation : AbstractValidator<ExcluirTarefaCommand>
        {
            public ExcluirTarefaValidation() 
            { 
                RuleFor(x => x.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Id da tarefa é obrigatório.");
            }
        }
    }
}
