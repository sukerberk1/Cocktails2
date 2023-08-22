using Cocktails2.Domain.Entities;
using Cocktails2.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Application.Services.Interfaces;

public interface ICocktailService
{
    public  Task<IReadOnlyCollection<Cocktail>> GetAllCocktailsAsync();

    public  Task<Cocktail> GetCocktailByIdAsync(int id);

    public Task<IReadOnlyCollection<Cocktail>> GetCocktailsStartingWithAsync(string prompt);

    public Task AddCocktailAsync(Cocktail cocktail);

    public Task ChangeIngredientPortionAmountAsync(IngredientPortion ingredient, int amount);
}
