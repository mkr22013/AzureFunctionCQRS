using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Persistence.Contexts;
using CleanArchitectrure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectrure.Persistence
{
    /// <summary>
    /// Configure services for persistence
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Add injection for persistence
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
            services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
