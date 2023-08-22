using Cocktails2.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Cocktails2.Application.Services.Interfaces;

namespace Cocktails2.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
    {
        services.AddScoped<ICocktailService, CocktailService>();
        services.AddScoped<IIngredientService, IngredientService>();

        return services;
    }
}
