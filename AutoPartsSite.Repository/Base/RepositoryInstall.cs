using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using AutoPartsSite.Repository.Modules.BlogCategory.Implements;
using AutoPartsSite.Repository.Modules.BlogCategory.Interfaces;
using AutoPartsSite.Repository.Modules.BlogPost.Implements;
using AutoPartsSite.Repository.Modules.BlogPost.Interfaces;
using AutoPartsSite.Repository.Modules.CollaborationRequest.Implements;
using AutoPartsSite.Repository.Modules.CollaborationRequest.Interfaces;
using AutoPartsSite.Repository.Modules.ContactMessage.Implements;
using AutoPartsSite.Repository.Modules.ContactMessage.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsSite.Repository.Base
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOffWork, UnitOfWork>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICollaborationRequestRepository, CollaborationRequestRepository>();   
            services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();


        }
    }
}
