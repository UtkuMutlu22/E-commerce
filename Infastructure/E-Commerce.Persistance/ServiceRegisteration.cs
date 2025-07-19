using E_Commerce.Application.Repository;
using E_Commerce.Persistance.Concretes;
using E_Commerce.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistance
{
    public static class ServiceRegisteration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<E_CommerceDbContext>(options =>
                options.UseSqlServer(EnviromentConfigurationSettings.SqlServerConnection));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            //services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            //services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            //services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            //services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        }
    }
}
