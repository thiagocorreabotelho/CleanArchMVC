using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interface;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Conexão com o banco

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #endregion Conexão com o banco

            #region Repositórios

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProducrRepository, ProductRepository>();

            #endregion Repositórios

            #region Services

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            #endregion Services

            #region Configuração do AutoMapper

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            #endregion Configuração do AutoMapper

            return services;
        }
    }
}