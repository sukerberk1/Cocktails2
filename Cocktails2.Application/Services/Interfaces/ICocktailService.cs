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
    public  Task<IReadOnlyCollection<Cocktail>> GetAllCocktails();

    public  Task<Cocktail> GetCocktailById(int id);

    public Task<IReadOnlyCollection<Cocktail>> GetCocktailsStartingWith(string prompt);

    public Task AddCocktail(Cocktail cocktail);

    public Task ChangeIngredientPortionAmount(IngredientPortion ingredient, int amount);
}
