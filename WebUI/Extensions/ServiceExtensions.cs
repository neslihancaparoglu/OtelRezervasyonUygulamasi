using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Repository.EFCore;
using Repository;
using System.Reflection.PortableExecutable;
using System.Reflection;
using Repository.EFCore.Config;
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
        public static void ConfiguerRepostoryManager(this IServiceCollection services)
        {
            
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IRepositoryAboutUs, RepositoryAboutUs>();
            services.AddScoped<IRepositoryBase<User>, RepositoryBase<User>>();
          
        }
        public static void ConfiguerServiceManager(this IServiceCollection services)
        { // service referanslar

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IUserService, UserService>();
            


        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>
                (
                    opts =>
                    {
                        opts.Password.RequireDigit = true;
                        opts.Password.RequireLowercase = true;
                        opts.Password.RequireUppercase = true;
                        opts.Password.RequireNonAlphanumeric = true;
                        opts.Password.RequiredLength = 8;

                        opts.User.RequireUniqueEmail = true;

                    }
                ).AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
