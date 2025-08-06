namespace E_Commerce.Persistance
{
    using E_Commerce.Application.Repository;
    using E_Commerce.Persistance.Concretes;
    using E_Commerce.Persistance.ConfigurationSettings;
    using E_Commerce.Persistance.Contexts;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for registering persistence layer services.
    /// </summary>
    public static class PersistanceServiceRegisteration
    {
        /// <summary>
        /// Registers database context and repository implementations to the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to which the persistence services will be added.</param>
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(DbConfigurationSettings.SqlServerConnection));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        }
    }
}
