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
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
