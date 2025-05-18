using Microsoft.Extensions.DependencyInjection;
using School.Application.Services;
using System.Reflection;

namespace School.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICoursService, CourseService>();
            return services;
        }
    }
}
