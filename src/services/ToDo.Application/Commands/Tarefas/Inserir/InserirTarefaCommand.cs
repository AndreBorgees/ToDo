using Core.Messages;
using FluentValidation;
using ToDo.Domain.Enums;

namespace ToDo.Application.Commands.Tarefas.Inserir
{
    public class InserirTarefaCommand: Command
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new InserirTarefaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class InserirTarefaValidation : AbstractValidator<InserirTarefaCommand>
        {
            public InserirTarefaValidation() 
            {
                RuleFor(c => c.Titulo)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Titulo da tarefa é obrigatório.");

                RuleFor(c => c.Descricao)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Descricao da tarefa é obrigatório.");

                RuleFor(c => c.DataCriacao)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Data de conclusão da tarefa é obrigatório.");

                RuleFor(c => c.DataConclusao)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Data de conclusão tarefa é obrigatório.");

                RuleFor(c => c.Status)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Status da tarefa é obrigatório.");

                RuleFor(c => c.Prioridade)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Prioridade da tarefa é obrigatório.");
            }
        }
    }
}
