using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.Categorias.Atualizar
{
    public class AtualizarCategoriaCommand: Command
    {
        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoriaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateCategoriaValidation : AbstractValidator<AtualizarCategoriaCommand>
        {
            public UpdateCategoriaValidation()
            {
                RuleFor(c => c.IdCategoria)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("O Id da categoria é obrigatório.");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Nome da categoria é obrigatório.");

                RuleFor(c => c.Cor)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Cor da categoria é obrigatório.");
            }
        }
    }
}
