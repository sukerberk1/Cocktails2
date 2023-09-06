using Cocktails2.Domain.Common;

namespace Cocktails2.Persistence.DAO
{
    public class IngredientDao : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string Type { get; set; }

        // taste

        public double Sourness { get; init; }
        public double Sweetness { get; init; }
        public double Bitterness { get; init; }
        public double Creaminess { get; init; }
        public double Spiciness { get; init; }
        // strength is a 'multplier' of the taste. Default for alcohols and mixers: 1 
        public double Strength { get; init; }

    }
}
