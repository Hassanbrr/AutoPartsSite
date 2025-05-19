using AutoPartsSite.Repository.Base;

namespace AutoPartsSite.Presentation.Web.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddCustomServicesToContainer(this IServiceCollection services, IConfiguration configuration)
        {
           
            // Add services to the container.
            services.AddControllersWithViews();
          
          

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<DbContext, ApplicationDbContext>();
          
 
           
            services.InstallRepositories();
       
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
