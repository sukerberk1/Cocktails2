using Cocktails2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    internal class Cocktail : BaseAuditableEntity
    {
        private List<CocktailIngredient> _ingredients = new();

        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public IReadOnlyCollection<CocktailIngredient> Ingredients => _ingredients.AsReadOnly();

    }
}
