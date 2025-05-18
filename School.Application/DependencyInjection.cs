using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Bahavoir;
using School.Application.Handlers.CourseHandelers.Commands_.CreateCourse;
using School.Application.Services;
using System.Reflection;


namespace School.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(RequestResponseLoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            //validator service
           // services.AddValidatorsFromAssemblyContaining<CreateCourseValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICoursService, CourseService>();
         
            return services;
        }
    }
}
