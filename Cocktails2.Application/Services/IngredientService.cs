using Cocktails2.Application.Services.Interfaces;
using Cocktails2.Domain.Entities;
using Cocktails2.Persistence.DAO.Mapping;
using Cocktails2.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Application.Services;


internal class IngredientService : IIngredientService
{

    private ApplicationDbContext _context;
    private ILogger<IngredientService> _logger;

    public IngredientService(ApplicationDbContext context, ILogger<IngredientService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddIngredient(Ingredient ingredient)
    {
        _context.ChangeTracker.Clear();
        await _context.Ingredients.AddAsync(ingredient.ToDao());
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Ingredient>> GetAllIngredientsAsync()
    {
        var ingredientDaos = await _context.Ingredients.AsNoTracking().ToListAsync();
        return ingredientDaos.ConvertAll(ingredient => ingredient.ToDomainEntity());
    }

    public async Task<Ingredient?> GetIngredientByIdAsync(int id)
    {
        var ingredientDao = await _context.Ingredients.FindAsync(id);
        return ingredientDao.ToDomainEntity();
    }

    public async Task<List<Ingredient>> GetIngredientsByNameAsync(string name)
    { 
        var ingredientDaos = await _context.Ingredients.AsNoTracking().Where(o=>o.Name.StartsWith(name)).ToListAsync();
        return ingredientDaos.ConvertAll(x=> x.ToDomainEntity());
    }

    public async Task UpdateIngredient(Ingredient ingredient)
    {
        var dao = ingredient.ToDao();
        _context.Entry(dao).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
