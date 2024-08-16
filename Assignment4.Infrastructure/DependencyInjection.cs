using Assignment4.Application.Interfaces;
using Assignment4.Application.Services;
using Assignment4.Domain.Interfaces;
using Assignment4.Infrastructure.Data;
using Assignment4.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment4.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Register LibraryContext
            services.AddDbContext<LibraryContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookManagerRepository, BookManagerRepository>();
            services.AddScoped<IBookManagerService, BookManagerService>();

            return services;

        }
    }
}
