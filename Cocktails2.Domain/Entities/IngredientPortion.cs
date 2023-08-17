using Cocktails2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class IngredientPortion : BaseEntity
    {
        public int CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
