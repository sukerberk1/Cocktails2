using Cocktails2.Domain.Common;
using Cocktails2.Domain.Enums;
using Cocktails2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class Cocktail : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Picture Photo { get; set; }
        public CocktailOrigin Origin { get; set; }
        public ICollection<IngredientPortion> IngredientPortions { get; set; }

        public bool IsValid()
        {
            if (Name != null && Name.Length > 3 &&
                Description != null && Description.Length > 10 &&
                Photo != null &&
                IngredientPortions != null &&
                IngredientPortions.All(ip=>ip.Amount > 0)
                ) return true;
            else
            return false;
        }

        public Dictionary<string, double> GetTasteExperience()
        {
            var tasteExperience = new Dictionary<string, double>();
            var tasteProperties = IngredientPortions.FirstOrDefault().Ingredient.TasteParameters.GetType().GetProperties();

            foreach (var tasteProp in tasteProperties)
            {
                if (tasteProp.Name == "Strength") continue;
                tasteExperience[tasteProp.Name] = 0.0;
            }

            foreach (var portion in IngredientPortions)
            {
                double ingredientStrength = portion.Ingredient.TasteParameters.Strength;
                foreach (PropertyInfo tasteProperty in tasteProperties)
                {
                    if (tasteProperty.Name == "Strength") continue;
                    var tasteValueRaw = (double) tasteProperty.GetValue(portion.Ingredient.TasteParameters);
                    double tasteValueMultiplied = tasteValueRaw * portion.Amount * ingredientStrength;
                    tasteExperience[tasteProperty.Name] += tasteValueMultiplied;
                }
            }

            return tasteExperience;
        }

    }
}
