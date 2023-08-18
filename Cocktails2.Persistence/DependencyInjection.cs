using Cocktails2.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails2.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase("db"));

            return services;
        }

        public static IServiceProvider SeedDatabase(this IServiceProvider service)
        {
            var context = service.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DatabaseSeed.SeedWith(context);
            return service;
        }
    }
}
