using AutoPartsSite.Repository.Modules.Base.Implements;
using AutoPartsSite.Repository.Modules.Base.Interfaces;
using AutoPartsSite.Repository.Modules.BlogPost.Implements;
using AutoPartsSite.Repository.Modules.BlogPost.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AutoPartsSite.Repository.Base
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IBlogRepository, BlogRepository>();  // مخصوص وبلاگ
        }
    }
}
