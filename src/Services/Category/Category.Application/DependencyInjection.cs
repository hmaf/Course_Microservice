using Microsoft.Extensions.DependencyInjection;
using Category.Application.Servcies.IServices;
using Microsoft.Extensions.Configuration;
using Category.Application.Bahaviours;
using Category.Application.Contracts;
using Category.Application.Servcies;
using System.Reflection;
using FluentValidation;
using MediatR;

namespace Category.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configure)
        {
            services.Configure<AppSettings>(configure.GetSection("AppSettings"));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IFileService, FileService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

            return services;
        }
    }
}
