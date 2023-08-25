using DoMains.AppDbContext;
using DoMains.DTO;
using DoMains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SeafoodApi.Configurations;
using SeafoodApi.Interfaces;
using SeafoodApi.Middlewares;
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

            builder.Services.AddDIServices(builder.Configuration);
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserService, UserService>();

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
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseMiddleware<JwtMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}