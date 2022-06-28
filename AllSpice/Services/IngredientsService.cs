using System;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        private readonly RecipesService _rs;

        public IngredientsService(IngredientsRepository repo, RecipesService rs)
        {
            _repo = repo;
            _rs = rs;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            return _repo.CreateIngredient(ingredientData);
        }

        internal Ingredient Edit(Ingredient ingredientData)
        {
            Recipe recipe = _rs.GetById(ingredientData.RecipeId);
            ingredientData.RecipeId = recipe.Id;
            if (recipe.Creator != ingredientData.Creator)
            {
                throw new Exception("not yours to edit");
            }
            Ingredient original = _repo.GetById(ingredientData.Id);
            original.Name = ingredientData.Name ?? original.Name;
            original.Quantity = ingredientData.Quantity ?? original.Quantity;
            _repo.Edit(original);
            return original;

        }

        internal void Delete(int id, Account userInfo)
        {
            Ingredient ingredient = _repo.GetById(id);
            Recipe recipe = _rs.GetById(ingredient.RecipeId);
            if (recipe.CreatorId != userInfo.Id)
            {
                throw new Exception("not yours to delete");
            }
            _repo.Delete(id);
        }
    }
}