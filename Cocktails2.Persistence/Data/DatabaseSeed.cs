using Cocktails2.Persistence.DAO;
using Cocktails2.Persistence.Misc;
using Microsoft.EntityFrameworkCore;

namespace Cocktails2.Persistence.Data;

public static class DatabaseSeed
{

    public static async Task SeedWith<T>(T context) where T : ApplicationDbContext
    {
        Console.WriteLine("Seeding Database...");
        context.Ingredients.AddRange(
            new IngredientDao
            {
                Name = "Lemon",
                Description = "The lemon is a species of small evergreen tree in the flowering plant family Rutaceae, native to Asia, primarily Northeast India, Northern Myanmar, or China.",
                Type = "Garnish",
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://www.futurefit.co.uk/wp-content/uploads/2019/08/shutterstock_1934467364-scaled.jpg"),
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
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://s3.envato.com/files/316963755/Vodka001-1510.jpg"),
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
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://wszystkoojedzeniu.pl/site/assets/files/88354/coca-cola.650x0.jpg"),
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
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://m.media-amazon.com/images/I/71mt20VS7JL._AC_UF894,1000_QL80_.jpg"),
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
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://images.immediate.co.uk/production/volatile/sites/30/2020/08/sugar-syrup-7a60e54.jpg?quality=90&resize=440,400"),
                Sourness = 0, 
                Sweetness = 1, 
                Bitterness = 0, 
                Creaminess = 0.1,
                Spiciness = 0, 
                Strength = 1.2
            },
            new IngredientDao
            {
                Name = "Espresso",
                Description = "Espresso is generally thicker than coffee brewed by other methods, with a viscosity similar to that of warm honey. This is due to the higher concentration of suspended and dissolved solids, and the crema on top (a foam with a creamy consistency). As a result of the pressurized brewing process, the flavors and chemicals in a typical cup of espresso are very concentrated.",
                Type = "Mixer",
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://www.delonghi.com/medias/PL-LP-espresso-perfetto-Hero-mob.jpg?context=bWFzdGVyfHJvb3R8MzAzOTI1fGltYWdlL2pwZWd8aDM0L2g1Ni8xMjgwNDY3Njc4MDA2Mi9QTF9MUF9lc3ByZXNzby1wZXJmZXR0b19IZXJvX21vYi5qcGd8OGU0ZjE2OTBmYzBjMDgzNmE5MzM3ZTYzNzBhNzkyMTQwMzQ0OGM1ODlhZTAxZDVhMTFlNzE4N2JkM2ZjMDQ2Ng"),
                Sourness = 0.3,
                Sweetness = 0.1,
                Bitterness = 0.7,
                Creaminess = 0.1,
                Spiciness = 0.1,
                Strength = 1
            },
            new IngredientDao
            {
                Name= "Coffee Liqueur",
                Description = "Essentially, coffee liqueur is a blend of two of many people's favorite beverages: coffee and alcohol, plus some sugar to balance it out, come together to give the imbiber a shot of energy and liquid courage at the same time. It can be enjoyed on its own (usually over ice) or mixed into a cocktail.",
                Type = "Spirit",
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://media.lacucinaitaliana.com/photos/5f85af1d32296c94f6fb7c14/4:5/h_800,c_limit/Coffee%20liqueur%201.jpg") ,
                Sourness = 0.1,
                Sweetness = 0.4,
                Bitterness = 0.4,
                Creaminess = 0.2,
                Spiciness = 0.1,
                Strength = 1,
            }
            );
        context.SaveChanges();
        context.Cocktails.AddRange(
            new CocktailDao
            {
                Name = "Cuba Libre",
                Description = "Most accounts, including Cid's, of the creation of the Cuba Libre, agree that it dates back to Havana around 1900, after the Spanish-American War, which began and ended in 1898 and led to Cuban independence. The name of the drink, Cuba Libre, means “Free Cuba,” which was the battle cry of the Cuban Liberation Army.",
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://www.liquor.com/thmb/cpSgrrmR7SDnFDfvI150WYsF-Fo=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__01__02105149__Cuba-Libre-720x720-recipe-673b48bbef034d89b6b5149b8417c7d5.jpg"),
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
        CubaLibre.IngredientPortions = context.IngredientPortions.ToList();
        context.SaveChanges();

        var Vodka = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Vodka");
        var CoffeeLiqueur = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Coffee Liqueur");
        var Syrup = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Syrup");
        var Espresso = context.Ingredients.FirstOrDefault(ingredient => ingredient.Name == "Espresso");

        context.Cocktails.Add(
            new CocktailDao
            {
                Name = "Espresso Martini",
                Description = "The espresso martini, also known as a vodka espresso, is a cold caffeinated alcoholic drink made with espresso, coffee liqueur, and vodka. It is not a true martini as it contains neither gin nor vermouth, but is one of many drinks that incorporate the term martini into their names.",
                Photo = await ImageConverterService.ConvertUriToByteArrayAsync(@"https://images.immediate.co.uk/production/volatile/sites/30/2020/08/espresso-martini-f099531.jpg?quality=90&webp=true&resize=300,272"),
                Origin = "UnitedKingdom",
                IngredientPortions = 
                { 
                    new IngredientPortionDao
                    {
                        Ingredient = Vodka,
                        Amount = 60,
                    },
                    new IngredientPortionDao
                    {
                        Ingredient = CoffeeLiqueur,
                        Amount = 15,
                    },
                    new IngredientPortionDao
                    {
                        Ingredient = Syrup,
                        Amount = 15,
                    },
                    new IngredientPortionDao
                    {
                        Ingredient = Espresso,
                        Amount = 30
                    }
                }
            }
            );

        context.SaveChanges();

        Console.WriteLine("Database has been seeded");
    }

}
