using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.Categorias.Excluir
{
    public class ExcluirCategoriaCommand : Command
    {
        public Guid Id { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ExcluirCategoriaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class ExcluirCategoriaValidation : AbstractValidator<ExcluirCategoriaCommand>
        {
            public ExcluirCategoriaValidation()
            {
                RuleFor(c => c.Id)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Id da categoria é obrigatória.");
            }
        }
    }
}
