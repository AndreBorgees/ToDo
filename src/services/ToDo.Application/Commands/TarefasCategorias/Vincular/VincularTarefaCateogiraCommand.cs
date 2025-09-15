using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.TarefasCategorias.Vincular
{
    public class VincularTarefaCateogiraCommand : Command
    {
        public Guid IdTarefa { get; set; }
        public Guid IdCategoria { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new VincularTarefaCateogiraValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class VincularTarefaCateogiraValidation : AbstractValidator<VincularTarefaCateogiraCommand>
        {
            public VincularTarefaCateogiraValidation()
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
