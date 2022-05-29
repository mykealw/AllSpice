using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;
        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        //GET SELF => RELATIONSHIPS
        internal List<Recipe> GetRecipe()
        {
            return _repo.GetRecipe();
        }

        internal Recipe GetById(int id)
        {
            Recipe recipe = _repo.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Invalid Recipe Id");
            }
            return recipe;
        }

        //RELATIONSHIPS
        internal List<Ingredient> GetIngredientsByRecipe(int id)
        {
            return _repo.GetIngredientsByRecipe(id);
        }

        //POSTS
        internal Recipe Create(Recipe recipeData)
        {
            return _repo.Create(recipeData);
        }

        //PUTS
        internal Recipe Edit(Recipe recipeData)
        {
            Recipe original = GetById(recipeData.Id);
            if (original.CreatorId != recipeData.CreatorId)
            {
                throw new Exception("You do not own this Recipe.");
            }
            original.Picture = recipeData.Picture ?? original.Picture;
            original.Title = recipeData.Title ?? original.Title;
            original.Subtitle = recipeData.Subtitle ?? original.Subtitle;
            original.Category = recipeData.Category ?? original.Category;

            _repo.Edit(original);
            return GetById(original.Id);
        }


        //DELETES
        internal void Delete(int id, string userId)
        {
            Recipe recipe = GetById(id);
            if (recipe.CreatorId != userId)
            {
                throw new Exception("You do not own this Recipe.");
            }
            _repo.Delete(id);
        }
    }
}