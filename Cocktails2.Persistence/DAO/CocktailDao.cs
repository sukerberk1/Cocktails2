using Cocktails2.Domain.Common;


namespace Cocktails2.Persistence.DAO;

public class CocktailDao : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }
    public string Origin { get; set; }
    public List<IngredientPortionDao> IngredientPortions { get; set; } = new();
}
