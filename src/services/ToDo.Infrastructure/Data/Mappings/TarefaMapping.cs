using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infrastructure.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(tarefa => tarefa.Id);

            builder.Property(tarefa => tarefa.Titulo)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(tarefa => tarefa.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(tarefa => tarefa.DataCriacao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(tarefa => tarefa.DataConclusao)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(tarefa => tarefa.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(tarefa => tarefa.Prioridade)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Tarefas");

            builder.HasMany(tarefa => tarefa.Categorias)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "TarefaCategoria",
                    tarefaCategoria => tarefaCategoria.HasOne<Categoria>().WithMany().HasForeignKey("IdCategoria").HasPrincipalKey(nameof(Categoria.Id)),
                    tarefaCategoria => tarefaCategoria.HasOne<Tarefa>().WithMany().HasForeignKey("IdTarefa").HasPrincipalKey(nameof(Tarefa.Id)),
                    tarefaCategoria =>
                    {
                        tarefaCategoria.HasKey("IdTarefa", "IdCategoria");
                        tarefaCategoria.ToTable("TarefasCategorias");
                    });
        }
    }
}
