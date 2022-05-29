using System;
using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            string sql = @"
                INSERT INTO ingredients
                (name, quantity, recipeId)
                VALUE 
                (@Name, @Quantity, @RecipeId);
                SELECT LAST_INSERT_ID();";
            ingredientData.Id = _db.ExecuteScalar<int>(sql, ingredientData);
            return ingredientData;
        }

        // internal Ingredient Get(int id)
        // {
        //     string sql = @"
        //     SELECT
        //     a.*,
        //     i.*
        //     FROM ingredients i
        //     JOIN accounts a"
        // }
    }
}