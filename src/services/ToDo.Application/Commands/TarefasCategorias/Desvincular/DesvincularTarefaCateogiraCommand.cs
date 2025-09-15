using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.TarefasCategorias.Desvincular
{
    public class DesvincularTarefaCateogiraCommand : Command
    {
        public Guid IdTarefa { get; set; }
        public Guid IdCategoria { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DesvincularTarefaCateogiraValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DesvincularTarefaCateogiraValidation : AbstractValidator<DesvincularTarefaCateogiraCommand>
        {
            public DesvincularTarefaCateogiraValidation()
            {
                RuleFor(c => c.IdTarefa)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Id da Tarefa é obrigatório.");

                RuleFor(c => c.IdCategoria)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Id da Categoria é obrigatório.");
            }
        }
    }
}
