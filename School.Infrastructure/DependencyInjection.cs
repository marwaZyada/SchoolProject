using Microsoft.Extensions.DependencyInjection;
using School.Domain.Repositories.Interfaces.Generic;
using School.Infrastructure.Repositories;
using System.Reflection;

namespace School.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            return services;
        }
    }
}
