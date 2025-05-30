﻿using AutoPartsSite.Application.Base;
using AutoPartsSite.Application.DTOs.Validator;
using AutoPartsSite.Application.Profiles;
using AutoPartsSite.Repository.Base;
using AutoPartsSite.Repository.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsSite.Presentation.Web.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
       
        public static void AddCustomServicesToContainer(this IServiceCollection services, IConfiguration configuration)
        {

            // Add services to the container.
         
            services.AddFluentValidationAutoValidation(); // فعال‌سازی اتوماتیک ولیدیشن
            services.AddValidatorsFromAssemblyContaining<BlogPostValidator>();
            services.AddValidatorsFromAssemblyContaining<BlogCategoryValidator>();


            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddAutoMapper(typeof(BlogProfile).Assembly);
            services.InstallRepositories();
            services.InstallServices();
            //services.AddSingleton<ILoggerManager, LoggerManager>();
            //services.AddScoped<ITokenProvider, TokenProvider>();
            ////services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<ExceptionHandlingMiddleware>();
            ////services.AddTransient<AppAuthenticationMiddleware>();
            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq();
            //});
        }

    }
}
