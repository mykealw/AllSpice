using System.Linq;
using System.Collections.Generic;
using System.Data;
using Dapper;
using AllSpice.Models;

namespace AllSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        // GETS SELF => RELATIONSHIPS
        internal List<Recipe> GetRecipe()
        {
            string sql = @"
            SELECT
             r.*,
            act.*
            FROM recipes r
            JOIN accounts act ON r.creatorId = act.id;
             ";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipes, account) =>
            {
                recipes.Creator = account;
                return recipes;
            }).ToList();
        }

        internal Recipe GetById(int id)
        {
            string sql = @"
            Select
            r.*,
            act.*
            FROM recipes r
            JOIN accounts act ON r.creatorId = act.Id
            WHERE r.id = @id;";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipes, account) =>
            {
                recipes.Creator = account;
                return recipes;
            }, new { id }).FirstOrDefault();
        }

        // RELATIONSHIPS HERE
        internal List<Ingredient> GetIngredientsByRecipe(int id)
        {
            string sql = @"
            SELECT i.*
            FROM ingredients i
            WHERE i.recipeId = @id;";
            return _db.Query<Ingredient>(sql, new { id }).ToList();
        }

        internal List<Step> GetStepsByRecipe(int id)
        {
            string sql = @"
            SELECT s.*
            FROM steps s
            WHERE s.recipeId = @id;";
            return _db.Query<Step>(sql, new { id }).ToList();
        }

        // POSTS
        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (picture, title, subtitle, category, creatorId)
            VALUES
            (@picture, @title, @subtitle, @category, @creatorId);
            SELECT LAST_INSERT_ID();";
            recipeData.Id = _db.ExecuteScalar<int>(sql, recipeData);
            return recipeData;
        }

        //PUTS
        internal void Edit(Recipe original)
        {
            string sql = @"
                UPDATE recipes
                SET
                picture = @Picture,
                title = @Title,
                Subtitle = @Subtitle,
                category = @Category
                WHERE id = @Id;";
            _db.Execute(sql, original);
        }

        //DELETES
        internal void Delete(int id)
        {
            string sql = "DELETE FROM recipes WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}