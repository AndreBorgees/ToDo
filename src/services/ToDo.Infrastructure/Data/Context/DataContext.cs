using Core.Data;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Entities.Tarefas;

namespace ToDo.Infrastructure.Data.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);         
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public async Task<bool> CommitAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
