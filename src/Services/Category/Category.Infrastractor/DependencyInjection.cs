using Category.Domain.Repositories;
using Category.Infrastractor.MongoDbDrive.Data;
using Category.Infrastractor.MongoDbDrive.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Category.Infrastractor
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastractor(this IServiceCollection services)
        {
            services.AddScoped<ICategoryContext, CategoryContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
