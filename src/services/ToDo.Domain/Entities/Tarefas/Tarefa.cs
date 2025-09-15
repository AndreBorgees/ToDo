using Core.DomainObjects;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities.Tarefas
{
    public class Tarefa : Entity, IAggrgateRoot
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataConclusao { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }

        private readonly List<Categoria> _categorias = new List<Categoria>();
        public IReadOnlyCollection<Categoria> Categorias => _categorias;

        public Tarefa(string titulo,
            string descricao,
            DateTime dataCriacao,
            DateTime dataConclusao,
            StatusTarefa status,
            PrioridadeTarefa prioridade)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = status;
            Prioridade = prioridade;
        }

        public void Atualizar(string titulo,
            string descricao,
            DateTime dataCriacao,
            DateTime dataConclusao,
            StatusTarefa status,
            PrioridadeTarefa prioridade)
        {
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataConclusao = dataConclusao;
            Status = status;
            Prioridade = prioridade;
        }

        public void VincularCategoria(Categoria categoria)
        {
            if(categoria is null) throw new ArgumentNullException(nameof(categoria));

            if (_categorias.Any(c => c.Id == categoria.Id)) return;

            _categorias.Add(categoria);
        }

        public void DisvincularCategoria(Categoria categoria)
        {
            if (categoria is null) throw new ArgumentNullException(nameof(categoria));

            _categorias.Remove(categoria);
        }
    }
}
