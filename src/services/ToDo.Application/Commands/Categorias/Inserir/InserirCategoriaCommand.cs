using Core.Messages;
using FluentValidation;

namespace ToDo.Application.Commands.Categorias.Inserir
{
    public class InserirCategoriaCommand : Command
    {
        public string Nome { get; set; }
        public string Cor { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new InserirCategoriaValidation().Validate(this);
            return ValidationResult.IsValid;
        }
 
        public class InserirCategoriaValidation : AbstractValidator<InserirCategoriaCommand>
        {
            public InserirCategoriaValidation()
            {
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
