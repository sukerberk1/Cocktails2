using Cocktails2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Cocktails2.Application.Services.Interfaces;
using Cocktails2.Persistence.Data;

namespace Cocktails2.Application.Services;


public class CocktailService : ICocktailService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger _logger;
    public CocktailService(ApplicationDbContext context, ILogger<CocktailService> logger) 
    { 
        _context = context;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<Cocktail>> GetAllCocktails()
    {
        var cocktails = await _context.Cocktails.Include(cock=>cock.IngredientPortions).ToListAsync();
        return cocktails;
    }

    public async Task<Cocktail> GetCocktailById(int id)
    {
        var cocktail = await _context.Cocktails.FindAsync(id);
        return cocktail;
    }
    
    public async Task<IReadOnlyCollection<Cocktail>> GetCocktailsStartingWith(string prompt)
    {
        var cocktails = await _context.Cocktails.Where(c => c.Name.StartsWith(prompt)).ToListAsync();
        return cocktails;
    }

    public async Task AddCocktail(Cocktail cocktail)
    {
        _context.Cocktails.Add(cocktail);
        await _context.SaveChangesAsync();
    }
     
    public async Task ChangeIngredientPortionAmount(IngredientPortion ingredient, int amount)
    {
        ingredient.Amount = amount;
        await _context.SaveChangesAsync();
    }
}
