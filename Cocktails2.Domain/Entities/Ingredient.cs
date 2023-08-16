using Cocktails2.Domain.Common;
using Cocktails2.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    internal class Ingredient : BaseAuditableEntity
    {
        private readonly List<CocktailIngredient> _cocktails = new();

        public string Name { get; set; }
        public string Description { get; set; }
        public IngredientType Type { get; set; }
        public TasteParameters TasteParameters { get; set; }
        public IReadOnlyCollection<CocktailIngredient> Cocktails => _cocktails.AsReadOnly();
    }
}
