using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Controllers;
using WebApi.Domain;
using WebApi.Repositories;

namespace WebApi
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterApplicationControllers(this IServiceCollection @this)
        {
            @this.AddScoped<SessionController, SessionController>();
            return @this;
        }
        
        public static IServiceCollection RegisterServices(this IServiceCollection @this)
        {
            return @this;
        }
        
        public static IServiceCollection RegisterDatabase(this IServiceCollection @this, string connectionString)
        {
            @this.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return @this;
        }
        
        public static IServiceCollection RegisterRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            @this.AddScoped<ICalcellationTokenProvider, HttpContextCancellationTokenProvider>();
            
            @this.AddScoped<ISessionRepository, SessionRepository>();
            return @this;
        }
        
        public static IServiceCollection RegisterHealthChecks(this IServiceCollection services, string databaseConnectionString)
        {
           

            return services;
        }
        
        public static IServiceCollection RegisterDomainEvents(this IServiceCollection @this)
        {
            return @this;
        }
    }
}