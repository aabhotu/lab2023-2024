using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PractiveRoom.Contracts;
using PractiveRoom.Repository;
using RestApi.Contracts;
using RestApi.Entities;
using RestApi.Repository;

namespace RestApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigMySqlConnection(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("DatabaseConnection");
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connection,
               MySqlServerVersion.LatestSupportedServerVersion
             ));
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
