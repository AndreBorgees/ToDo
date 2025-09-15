using ToDo.Domain.Enums;

namespace ToDo.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; init; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
    }
}
