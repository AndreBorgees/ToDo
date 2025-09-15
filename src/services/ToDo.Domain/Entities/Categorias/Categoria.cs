using Core.DomainObjects;

namespace ToDo.Domain.Entities.Categorias
{
    public class Categoria : Entity, IAggrgateRoot
    {
        public string Nome { get; private set; }
        public string Cor { get; private set; }

        public Categoria(string nome, string cor)
        {
            Nome = nome;
            Cor = cor;
        }

        public void Atualizar(string nome, string cor)
        {
            Nome = nome;
            Cor = cor;
        }
    }
}
