using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.RepositoryUserClasses;
using Service;
using Service.Contracts;
using System.Runtime.CompilerServices;
using System.Text;

namespace GeorgianFoodReviewAPI.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });


        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
                        IConfiguration configuration) =>
                        services.AddDbContext<RepositoryContext>(opts =>
                        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));



      


        //public static void ConfigureSwagger(this IServiceCollection services)
        //{

        //    services.AddSwaggerGen(s =>
        //    {
        //        s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //        {
        //            In = ParameterLocation.Header,
        //            Description = "Place to add JWT with Bearer",
        //            Name = "Authorization",
        //            Type = SecuritySchemeType.ApiKey,
        //            Scheme = "Bearer"
        //        });

        //        s.AddSecurityRequirement(new OpenApiSecurityRequirement()
        //     {
        //         {
        //             new OpenApiSecurityScheme
        //             {
        //                 Reference = new OpenApiReference
        //                 {
        //                     Type = ReferenceType.SecurityScheme,
        //                     Id = "Bearer"
        //                 }, 
        //                 Name = "Bearer",
        //             },
        //             new List<string>()
        //         }
        //     });

        //    });

        //}

        public static void ConfigureAuthenticationHandler(this IServiceCollection services) =>
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5005";
                options.Audience = "georgianfoodreviewapi";
            });
       

        


    }
}
