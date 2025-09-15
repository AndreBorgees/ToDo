using Core.Messages;
using FluentValidation;
using ToDo.Domain.Enums;

namespace ToDo.Application.Commands.Tarefas.Atualizar
{
    public class AtualizarTarefaCommand : Command
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }






        public override bool IsValid()
        {
            ValidationResult = new AtualizarTarefaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarTarefaValidation : AbstractValidator<AtualizarTarefaCommand>
        {
            public AtualizarTarefaValidation()
            {
                RuleFor(c => c.Id)
                   .NotEmpty()
                   .NotNull()
                   .WithMessage("Id da tarefa é obrigatório.");

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
