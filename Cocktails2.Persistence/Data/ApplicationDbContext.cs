using Cocktails2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { }

    public DbSet<Cocktail> Cocktails { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientPortion> IngredientsPortions { get; set; }

}
