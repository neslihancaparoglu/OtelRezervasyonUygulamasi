using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.EFCore;
using Repository;
using System.Reflection.PortableExecutable;
using System.Reflection;
using Services.Contracts;
using Services.EFCore;

namespace WebUI.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfiguratioSQLContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repository")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IRepositoryBase<User>, RepositoryBase<User>>();
          
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        { // service referanslar

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUserService, UserService>();
            


        }
        
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
