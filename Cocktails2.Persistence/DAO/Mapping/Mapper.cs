using Cocktails2.Domain.Entities;
using Cocktails2.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace Cocktails2.Persistence.DAO.Mapping;

public static class Mapper
{
    public static Cocktail ToDomainEntity(this CocktailDao dao) => new()
    {
        Id = dao.Id,
        Name = dao.Name,
        Description = dao.Description,
        PhotoUrl = new Uri(dao.PhotoUrl),
        Origin = (CocktailOrigin)Enum.Parse(typeof(CocktailOrigin), dao.Origin),
        CreatedOn = dao.CreatedOn,
        UpdatedOn = dao.UpdatedOn,
    };

    public static CocktailDao ToDao(this Cocktail entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        PhotoUrl = entity.PhotoUrl.AbsolutePath,
        Origin = nameof(entity.Origin),
        CreatedOn = entity.CreatedOn,
        UpdatedOn = entity.UpdatedOn,
        IngredientPortions = entity.IngredientPortions.ToList().ConvertAll(portion => portion.ToDao()),
    };

    public static Ingredient ToDomainEntity(this IngredientDao dao) => new()
    {
        Id = dao.Id,
        Name = dao.Name,
        Description = dao.Description,
        PhotoUrl = new Uri(dao.PhotoUrl),
        CreatedOn = dao.CreatedOn,
        UpdatedOn = dao.UpdatedOn,
        Type = (IngredientType)Enum.Parse(typeof(IngredientType), dao.Type),
        TasteParameters = new()
        {
            Sourness = dao.Sourness,
            Spiciness = dao.Spiciness,
            Sweetness = dao.Sweetness,
            Strength = dao.Strength,
            Bitterness = dao.Bitterness,
            Creaminess = dao.Creaminess
        }
    };

    public static IngredientDao ToDao(this Ingredient entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        PhotoUrl = entity.PhotoUrl.AbsolutePath,
        CreatedOn = entity.CreatedOn,
        UpdatedOn = entity.UpdatedOn,
        Type = nameof(entity.Type),
        Sourness = entity.TasteParameters.Sourness,
        Spiciness = entity.TasteParameters.Spiciness,
        Sweetness = entity.TasteParameters.Sweetness,
        Strength = entity.TasteParameters.Strength,
        Bitterness = entity.TasteParameters.Bitterness,
        Creaminess = entity.TasteParameters.Creaminess
    };

    public static IngredientPortionDao ToDao(this IngredientPortion entity) => new()
    {
        IngredientId = entity.Ingredient.Id,
        Ingredient = entity.Ingredient.ToDao(),
        Amount = entity.Amount,
    };

    public static IngredientPortion ToDomainEntity(this IngredientPortionDao dao) => new()
    {
        Ingredient = dao.Ingredient.ToDomainEntity(),
        Amount = dao.Amount,
    };
}
