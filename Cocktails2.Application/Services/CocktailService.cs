using Cocktails2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Cocktails2.Application.Services.Interfaces;
using Cocktails2.Persistence.Data;
using Cocktails2.Persistence.DAO.Mapping;
using Cocktails2.Persistence.DAO;
using Cocktails2.Domain.Enums;

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

    public async Task<IReadOnlyCollection<Cocktail>> GetAllCocktailsAsync()
    {
        var cocktailDaos = await _context.Cocktails.AsNoTracking().Include(cock => cock.IngredientPortions).ThenInclude(x => x.Ingredient).ToListAsync();
        var cocktails = cocktailDaos.ConvertAll( dao => dao.ToDomainEntity() );
        return cocktails;
    }

    public async Task<Cocktail> GetCocktailByIdAsync(int id)
    {
        var cocktailDao = await _context.Cocktails.Where(o => o.Id == id).Include(c => c.IngredientPortions).ThenInclude(ip => ip.Ingredient).FirstOrDefaultAsync();
        return cocktailDao.ToDomainEntity();
    }
    
    public async Task<IReadOnlyCollection<Cocktail>> GetCocktailsStartingWithAsync(string prompt)
    {
        var cocktailDaos = await _context.Cocktails.Where(c => c.Name.StartsWith(prompt)).ToListAsync();
        return cocktailDaos.ConvertAll( dao => dao.ToDomainEntity());
    }

    public async Task AddCocktailAsync(Cocktail cocktail)
    {
        CocktailDao cocktailDao = cocktail.ToDao();

        foreach (var ingr in cocktailDao.IngredientPortions.ConvertAll(ip=>ip.Ingredient))
        {
            _context.Attach(ingr);
        }
        _context.Add(cocktailDao);

        await _context.SaveChangesAsync();
    }

    public async Task ChangeIngredientPortionAmountAsync(IngredientPortion ingredient, int amount)
    {
        throw new NotImplementedException();
    }
}
