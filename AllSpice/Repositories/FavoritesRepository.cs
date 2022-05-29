using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;
        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite Create(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (recipeId, accountId)
            VALUES
            (@RecipeId, @AccountId);
            SELECT LAST_INSERT_ID();";
            favoriteData.Id = _db.ExecuteScalar<int>(sql, favoriteData);
            return favoriteData;
        }

        internal Favorite GetById(int id)
        {
            string sql = @"
                SELECT 
                *
                FROM favorites
                WHERE id = @id;";
            return _db.QueryFirstOrDefault<Favorite>(sql, new { id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM favorites WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal List<FavoriteRecipeViewModel> GetFavoritesByAccount(string id)
        {
            string sql = @"
            SELECT 
            act.*,
            f.*,
            r.*
            FROM favorites f
            JOIN recipes r ON f.recipeId = r.id
            JOIN accounts act ON r.creatorId = a.id
            WHERE f.accountId = @id;
            ";
            List<FavoriteRecipeViewModel> recipes = _db.Query<Account, Favorite, FavoriteRecipeViewModel, FavoriteRecipeViewModel>(sql, (act, f, r)=>
            {
                r.Creator = act;
                r.FavoriteId = f.Id;
                return r;
            }, new{id}).ToList<FavoriteRecipeViewModel>();
            return recipes;
        }
    }
}