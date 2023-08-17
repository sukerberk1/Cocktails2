﻿using Cocktails2.Domain.Common;
using Cocktails2.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class Cocktail : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri PhotoUrl { get; set; }
        public CocktailOrigin Origin { get; set; }
        public ICollection<IngredientPortion> IngredientPortions { get; set; }
    }
}
