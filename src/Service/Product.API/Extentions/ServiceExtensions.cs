using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Product.API.Persistence;
using Product.API.Repositories;
using Product.API.Repositories.Interface;
using System.Reflection.Metadata.Ecma335;


namespace Product.API.Extentions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            

            services.AddControllers();
            services.Configure<RouteOptions>(options => options.LowercaseUrls =true);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
            services.ConfigureProductDbContext(configuration);
            services.AddInfrastructureServices();
            
            
            return services;
        }
        private static IServiceCollection ConfigureProductDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            var builder=new MySqlConnectionStringBuilder(connectionString);

            services.AddDbContext<ProductContext>(options => options.UseMySql(builder.ConnectionString, ServerVersion.AutoDetect(builder.ConnectionString), e =>
            {
                e.MigrationsAssembly("Product.API");
                e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
            }));

            return services;
        }
        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepositoryBaseAsync<,,>), typeof(RepositoryBaseAsync<,,>))
                .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>))
                .AddScoped<IProductRepository,ProductRepositoy>();
            
        }
        
        
    }
}
