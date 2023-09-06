using Cocktails2.Domain.Common;
using Cocktails2.Domain.Enums;
using Cocktails2.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails2.Domain.Entities
{
    public class Ingredient : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Picture Photo { get; set; }
        public IngredientType Type { get; set; }
        public TasteParameters TasteParameters { get; set; }
    }
}
