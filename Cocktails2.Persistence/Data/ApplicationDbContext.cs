using Microsoft.EntityFrameworkCore;
using Cocktails2.Persistence.DAO;

namespace Cocktails2.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence<int>("CocktailIdSequence");
        modelBuilder.Entity<CocktailDao>().Property(cock => cock.Id).HasDefaultValueSql("NEXT VALUE FOR CocktailIdSequence");

        modelBuilder.HasSequence<int>("IngredientIdSequence");
        modelBuilder.Entity<CocktailDao>().Property(cock => cock.Id).HasDefaultValueSql("NEXT VALUE FOR IngredientIdSequence");

        modelBuilder.HasSequence<int>("IngredientPortionIdSequence");
        modelBuilder.Entity<CocktailDao>().Property(cock => cock.Id).HasDefaultValueSql("NEXT VALUE FOR IngredientPortionIdSequence");

    }
    public DbSet<CocktailDao> Cocktails { get; set; }
    public DbSet<IngredientDao> Ingredients { get; set; }
    public DbSet<IngredientPortionDao> IngredientPortions { get; set; }

}
