using AutoPartsSite.Application.InterFaces;
using AutoPartsSite.Application.Services;
using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsSite.Application.Base
{
    public static class ServiceInstall
    {
        public static void InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICollaborationRequestService, CollaborationRequestService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IBlogCategoryService, BlogCategoryService>();

        }
    }
}
