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

        internal Ingredient GetById(int id)
        {
            string sql = "SELECT * FROM ingredients WHERE id = @id;";
            return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
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

        internal void Edit(Ingredient ingredientData)
        {
            string sql = @"
            UPDATE ingredients 
            SET
            name = @Name,
            quantity = @Quantity,
            WHERE id = @id;";
            _db.Execute(sql, ingredientData);
            // return ingredientData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM ingredients WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}