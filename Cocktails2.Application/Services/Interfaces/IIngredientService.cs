using Cocktails2.Domain.Entities;

namespace Cocktails2.Application.Services.Interfaces;

public interface IIngredientService
{
    public Task<IReadOnlyCollection<Ingredient>> GetAllIngredientsAsync();
    public Task<Ingredient?> GetIngredientByIdAsync(int id);
    public Task<List<Ingredient>> GetIngredientsByNameAsync(string name);
    public Task AddIngredient(Ingredient ingredient);
    public Task UpdateIngredient(Ingredient ingredient);
}
