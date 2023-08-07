using DoMains.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeafoodServices.Interfaces;
using SeafoodServices.Mappers;
using SeafoodServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodServices.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SeafoodContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddAutoMapper(typeof(CategoryMapper).Assembly);
            services.AddAutoMapper(typeof(UserMapper).Assembly);

            return services;
        }
    }
}
