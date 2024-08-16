using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment4.Infrastructure.Data
{
    public class LibraryContextFactory:IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\Risyad Kamarullah\\source\\repos\\Assignment4\\Assignment4.WebAPI\\appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.ConfigureInfrastructure(configuration);

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider.GetRequiredService<LibraryContext>();
        }
    }
}
