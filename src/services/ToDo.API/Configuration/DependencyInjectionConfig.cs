using Core.Mediator;
using FluentValidation.Results;
using MediatR;
using ToDo.Application.Commands.Categorias.Atualizar;
using ToDo.Application.Commands.Categorias.Excluir;
using ToDo.Application.Commands.Categorias.Inserir;
using ToDo.Application.Commands.Tarefas.Atualizar;
using ToDo.Application.Commands.Tarefas.Excluir;
using ToDo.Application.Commands.Tarefas.Inserir;
using ToDo.Application.Commands.TarefasCategorias.Desvincular;
using ToDo.Application.Commands.TarefasCategorias.Vincular;
using ToDo.Application.Queries.Categorias;
using ToDo.Application.Queries.Tarefas;
using ToDo.Domain.Entities.Categorias;
using ToDo.Domain.Entities.Tarefas;
using ToDo.Infrastructure.Data.Context;
using ToDo.Infrastructure.Data.Repositories;

namespace ToDo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<InserirCategoriaCommand, ValidationResult>, InserirCategoriaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarCategoriaCommand, ValidationResult>, AtualizarCategoriaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirCategoriaCommand, ValidationResult>, ExcluirCategoriaCommandHandler>();

            services.AddScoped<IRequestHandler<InserirTarefaCommand, ValidationResult>, InserirTarefaCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarTarefaCommand, ValidationResult>, AtualizarTarefaCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirTarefaCommand, ValidationResult>, ExcluirTarefaCommandHandler>();

            services.AddScoped<IRequestHandler<VincularTarefaCateogiraCommand, ValidationResult>, VincularTarefaCateogiraCommandHandler>();
            services.AddScoped<IRequestHandler<DesvincularTarefaCateogiraCommand, ValidationResult>, DesvincularTarefaCateogiraCommandHandler>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Data
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<DataContext>();

            // Queries
            services.AddScoped<ICategoriaQueries, CategoriaQueries>();
            services.AddScoped<ITarefaQueries, TarefaQueries>();
        }
    }
}
