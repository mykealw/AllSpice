using System;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
    public class StepsService
    {
        private readonly StepsRepository _repo;
        private readonly RecipesService _rs;

        public StepsService(StepsRepository repo, RecipesService rs)
        {
            _repo = repo;
            _rs = rs;
        }

        internal Step CreateStep(Step stepData)
        {
            return _repo.CreateStep(stepData);
        }

        internal Step Edit(Step stepData)
        {
            Recipe recipe = _rs.GetById(stepData.RecipeId);
            stepData.RecipeId = recipe.Id;
            if (recipe.Creator != stepData.Creator)
            {
                throw new Exception("not yours to edit");
            }
            Step original = _repo.GetById(stepData.Id);
            original.Body = stepData.Body ?? original.Body;
            _repo.Edit(original);
            return original;

        }

        internal void Delete(int id, Account userInfo)
        {
            Step step = _repo.GetById(id);
            if (step.Creator != userInfo)
            {
                throw new Exception("not yours to delete");
            }
            _repo.Delete(id);
        }
    }
}