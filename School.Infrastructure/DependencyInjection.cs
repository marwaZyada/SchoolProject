using Microsoft.Extensions.DependencyInjection;
using School.Domain.Repositories.Interfaces.Generic;
using School.Infrastructure.Repositories;
using School.Infrastructure.Service;
using System.Reflection;

namespace School.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped< IAccountService ,AccountService>();
            return services;
        }
    }
}
