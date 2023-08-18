using Cocktails2.Domain.Common;

namespace Cocktails2.Persistence.DAO;

public class IngredientPortionDao : BaseEntity
{
    public int IngredientId { get; set; }
    public IngredientDao Ingredient { get; set; }
    public int Amount { get; set; }
}
