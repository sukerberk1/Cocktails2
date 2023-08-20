using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cocktails2.Persistence.DAO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Cocktails2.Persistence.Data;

public static class DatabaseSeed
{


    //TODO: fix database seeding
    public static void SeedWith<T>(T context) where T : ApplicationDbContext
    {
        Console.WriteLine("Seeding Database...");
        context.Ingredients.AddRange(
            new IngredientDao
            {
                Name = "Lemon",
                Description = "The lemon is a species of small evergreen tree in the flowering plant family Rutaceae, native to Asia, primarily Northeast India, Northern Myanmar, or China.",
                Type = "Garnish",
                PhotoUrl = @"https://www.futurefit.co.uk/wp-content/uploads/2019/08/shutterstock_1934467364-scaled.jpg",
                Sourness = 1, 
                Bitterness = 0.5, 
                Spiciness = 0, 
                Creaminess = 0, 
                Strength = 0.5, 
                Sweetness = 0 
            },
            new IngredientDao
            {
                Name = "Vodka",
                Description = "Vodka is a clear distilled alcoholic beverage. Different varieties originated in Poland, Russia, and Sweden. Vodka is composed mainly of water and ethanol but sometimes with traces of impurities and flavourings.",
                Type = "Spirit",
                PhotoUrl = @"https://s3.envato.com/files/316963755/Vodka001-1510.jpg",
                Sourness = 0.1, 
                Bitterness = 0.7, 
                Spiciness = 0.7, 
                Creaminess = 0, 
                Strength = 1, 
                Sweetness = 0
            },
            new IngredientDao
            {
                Name = "Cola",
                Description = "Cola is a carbonated soft drink flavored with vanilla, cinnamon, citrus oils, and other flavorings. Cola became popular worldwide after the American pharmacist John Stith Pemberton invented Coca-Cola, a trademarked brand, in 1886, which was imitated by other manufacturers.",
                Type = "Mixer",
                PhotoUrl = @"https://wszystkoojedzeniu.pl/site/assets/files/88354/coca-cola.650x0.jpg",
                Sourness = 0, 
                Bitterness = 0,
                Spiciness = 0.1, 
                Creaminess = 0, 
                Strength = 1, 
                Sweetness = 0.9
            },
            new IngredientDao
            {
                Name = "Rum",
                Description = "Rum is a liquor made by fermenting and then distilling sugarcane molasses or sugarcane juice. The distillate, a clear liquid, is often aged in barrels of oak. Rum is produced in nearly every sugar-producing region of the world, such as the Philippines, where Tanduay is the largest producer of rum globally.",
                Type = "Spirit",
                PhotoUrl = @"https://m.media-amazon.com/images/I/71mt20VS7JL._AC_UF894,1000_QL80_.jpg",
                Sourness = 0, 
                Sweetness = 0, 
                Bitterness = 0.5, 
                Creaminess=0, 
                Strength = 1, 
                Spiciness = 0.7
            },
            new IngredientDao
            {
                Name = "Syrup",
                Description = "In cooking, syrup is a condiment that is a thick, viscous liquid consisting primarily of a solution of sugar in water, containing a large amount of dissolved sugars but showing little tendency to deposit crystals.",
                Type = "Flavoring",
                PhotoUrl = @"https://images.immediate.co.uk/production/volatile/sites/30/2020/08/sugar-syrup-7a60e54.jpg?quality=90&resize=440,400",
                Sourness = 0, 
                Sweetness = 1, 
                Bitterness = 0, 
                Creaminess = 0.1,
                Spiciness = 0, 
                Strength = 1.2
            }
            );
        context.SaveChanges();
        context.Cocktails.AddRange(
            new CocktailDao
            {
                Name = "Cuba Libre",
                Description = "Most accounts, including Cid's, of the creation of the Cuba Libre, agree that it dates back to Havana around 1900, after the Spanish-American War, which began and ended in 1898 and led to Cuban independence. The name of the drink, Cuba Libre, means “Free Cuba,” which was the battle cry of the Cuban Liberation Army.",
                PhotoUrl = @"https://www.liquor.com/thmb/cpSgrrmR7SDnFDfvI150WYsF-Fo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__01__02105149__Cuba-Libre-720x720-recipe-673b48bbef034d89b6b5149b8417c7d5.jpg",
                Origin = "Other",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
            }
            );
        context.SaveChanges();

       
        var Lemon = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Lemon");
        var Cola = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Cola");
        var Rum = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Rum");
        context.IngredientPortions.AddRange(
            new IngredientPortionDao
            {
                Ingredient = Rum,
                Amount = 40
            },
            new IngredientPortionDao
            {
                Ingredient = Cola,
                Amount = 150,
            },
            new IngredientPortionDao
            {
                Ingredient = Lemon,
                Amount = 1,
            }
            );
        context.SaveChanges();

        var CubaLibre = context.Cocktails.Include(cock => cock.IngredientPortions).FirstOrDefault(cocktail => cocktail.Name == "Cuba Libre");

        foreach (var ingr in context.IngredientPortions)
        {
            CubaLibre.IngredientPortions.Add(ingr);
            Console.WriteLine($"Added {ingr.Ingredient.Name} to Cuba Libre's ingredients");
        }

        context.SaveChanges();

        Console.WriteLine("Database has been seeded");
    }

}
