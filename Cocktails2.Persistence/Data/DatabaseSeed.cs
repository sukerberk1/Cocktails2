using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cocktails2.Domain.Entities;
using Cocktails2.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Cocktails2.Persistence.Data;

public static class DatabaseSeed
{

    public static void Seed(ApplicationDbContext context)
    {
        Console.WriteLine("Seeding Database...");
        context.Ingredients.AddRange(
            new Ingredient
            {
                Name = "Lemon",
                Description = "The lemon is a species of small evergreen tree in the flowering plant family Rutaceae, native to Asia, primarily Northeast India, Northern Myanmar, or China.",
                Type = IngredientType.Garnish,
                PhotoUrl = new Uri(@"https://www.futurefit.co.uk/wp-content/uploads/2019/08/shutterstock_1934467364-scaled.jpg"),
                TasteParameters = new TasteParameters { Sourness = 1, Bitterness = 0.5, Spiciness = 0, Creaminess = 0, Strength = 0.5, Sweetness = 0 }
            },
            new Ingredient
            {
                Name = "Vodka",
                Description = "Vodka is a clear distilled alcoholic beverage. Different varieties originated in Poland, Russia, and Sweden. Vodka is composed mainly of water and ethanol but sometimes with traces of impurities and flavourings.",
                Type = IngredientType.Spirit,
                PhotoUrl = new Uri(@"https://s3.envato.com/files/316963755/Vodka001-1510.jpg"),
                TasteParameters = new TasteParameters { Sourness = 0.1, Bitterness = 0.7, Spiciness = 0.7, Creaminess = 0, Strength = 1, Sweetness = 0 }
            },
            new Ingredient
            {
                Name = "Cola",
                Description = "Cola is a carbonated soft drink flavored with vanilla, cinnamon, citrus oils, and other flavorings. Cola became popular worldwide after the American pharmacist John Stith Pemberton invented Coca-Cola, a trademarked brand, in 1886, which was imitated by other manufacturers.",
                Type = IngredientType.Mixer,
                PhotoUrl = new Uri(@"https://wszystkoojedzeniu.pl/site/assets/files/88354/coca-cola.650x0.jpg"),
                TasteParameters = new TasteParameters { Sourness = 0, Bitterness = 0, Spiciness = 0.1, Creaminess = 0, Strength = 1, Sweetness = 0.9 }
            },
            new Ingredient
            {
                Name = "Rum",
                Description = "Rum is a liquor made by fermenting and then distilling sugarcane molasses or sugarcane juice. The distillate, a clear liquid, is often aged in barrels of oak. Rum is produced in nearly every sugar-producing region of the world, such as the Philippines, where Tanduay is the largest producer of rum globally.",
                Type = IngredientType.Spirit,
                PhotoUrl = new Uri(@"https://m.media-amazon.com/images/I/71mt20VS7JL._AC_UF894,1000_QL80_.jpg"),
                TasteParameters = new TasteParameters { Sourness = 0, Sweetness = 0, Bitterness = 0.5, Creaminess=0, Strength = 1, Spiciness = 0.7 }
            },
            new Ingredient
            {
                Name = "Syrup",
                Description = "In cooking, syrup is a condiment that is a thick, viscous liquid consisting primarily of a solution of sugar in water, containing a large amount of dissolved sugars but showing little tendency to deposit crystals.",
                Type = IngredientType.Flavoring,
                PhotoUrl = new Uri(@"https://images.immediate.co.uk/production/volatile/sites/30/2020/08/sugar-syrup-7a60e54.jpg?quality=90&resize=440,400"),
                TasteParameters = new TasteParameters { Sourness = 0, Sweetness = 1, Bitterness = 0, Creaminess = 0.1, Spiciness = 0, Strength = 1.2 }
            }
            );
        context.SaveChanges();
        context.Cocktails.AddRange(
            new Cocktail
            {
                Name = "Cuba Libre",
                Description = "",
                PhotoUrl = new Uri(@"https://www.liquor.com/thmb/cpSgrrmR7SDnFDfvI150WYsF-Fo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__01__02105149__Cuba-Libre-720x720-recipe-673b48bbef034d89b6b5149b8417c7d5.jpg"),
                Origin = CocktailOrigin.Other,
                CreatedOn = DateTime.Now,
            }
            );
        context.SaveChanges();

        var CubaLibre = context.Cocktails.FirstOrDefault(cocktail => cocktail.Name == "Cuba Libre");
        var Lemon = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Lemon");
        var Cola = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Cola");
        var Rum = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Rum");
        context.IngredientsPortions.AddRange(
            new IngredientPortion
            {
                Cocktail = CubaLibre,
                Ingredient = Rum,
                Amount = 40
            },
            new IngredientPortion
            {
                Cocktail = CubaLibre,
                Ingredient = Cola,
                Amount = 150,
            },
            new IngredientPortion
            {
                Cocktail = CubaLibre,
                Ingredient = Lemon,
                Amount = 1,
            }
            );
        context.SaveChanges();
        Console.WriteLine("Database has been seeded");
    }

}
