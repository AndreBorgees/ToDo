using Microsoft.EntityFrameworkCore;
using ToDo.Infrastructure.Data.Context;

namespace ToDo.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers();

            IConfiguration config = builder.Configuration;

            var stringDeConexao = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>(options =>
                options.UseSqlite(stringDeConexao));
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
