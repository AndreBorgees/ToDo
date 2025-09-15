using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities.Categorias;

namespace ToDo.Infrastructure.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(categoria => categoria.Id);

            builder.Property(categoria => categoria.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(categoria => categoria.Cor)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.ToTable("Categorias");
        }
    }
}
