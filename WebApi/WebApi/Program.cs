using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Seafood.Application.Mappers;
using Seafood.Application.Services.Adresses;
using Seafood.Application.Services.Categories;
using Seafood.Application.Services.Common;
using Seafood.Application.Services.Users;
using Seafood.Data.Dtos;
using Seafood.Data.EF;
using Seafood.Data.Entities;
using Seafood.WebApi.Configurations;
using Seafood.WebApi.Interfaces;
using Seafood.WebApi.Middlewares;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


//Add Cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader()
    .AllowAnyMethod());
});

// Add services to the container.

//string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
//string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
//byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidIssuer = issuer,
//        ValidateAudience = true,
//        ValidAudience = issuer,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ClockSkew = System.TimeSpan.Zero,
//        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
//    };
//});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger seafood", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
});

builder.Services.AddDbContext<SeafoodDbcontext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("seafoodDb")));

builder.Services.AddScoped<IGenericService<CategoryVM ,CategoryRequest>, CategoryService>();
builder.Services.AddScoped<IGenericService<ProductVM ,ProductRequest>, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly); ;
builder.Services.AddScoped<IJwtUtil, JwtUtil>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger seafood V1");
    });
//}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseMiddleware<JwtMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
