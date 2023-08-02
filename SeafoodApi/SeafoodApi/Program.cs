using DoMains.AppDbContext;
using DoMains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeafoodServices.Interfaces;
using SeafoodServices.Mappers;
using SeafoodServices.Repositories;
using SeafoodServices.ServiceExtension;
using SeafoodServices.Services;

namespace SeafoodApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddDbContext<SeafoodContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});
            //builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
          
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddDIServices(builder.Configuration);
            builder.Services.AddScoped<ICategoryService, CategoryService>();
           

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}