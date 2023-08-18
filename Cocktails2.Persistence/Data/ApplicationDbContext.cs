using Microsoft.EntityFrameworkCore;
using Cocktails2.Persistence.DAO;

namespace Cocktails2.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { }

    public DbSet<CocktailDao> Cocktails { get; set; }
    public DbSet<IngredientDao> Ingredients { get; set; }
    public DbSet<IngredientPortionDao> IngredientsPortions { get; set; }

}
