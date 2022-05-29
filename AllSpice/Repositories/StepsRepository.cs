using System.Data;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;
        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Step GetById(int id)
        {
            string sql = "SELECT * FROM steps WHERE id = @id;";
            return _db.QueryFirstOrDefault<Step>(sql, new { id });
        }

        internal Step CreateStep(Step stepData)
        {
            string sql = @"
                INSERT INTO steps
                (position, body, recipeId)
                VALUE 
                (@Position, @Body, @RecipeId);
                SELECT LAST_INSERT_ID();";
            stepData.Id = _db.ExecuteScalar<int>(sql, stepData);
            return stepData;
        }

        internal void Edit(Step stepData)
        {
            string sql = @"
            UPDATE steps 
            SET
            name = @Name,
            quantity = @Quantity,
            WHERE id = @id;";
            _db.Execute(sql, stepData);
            // return stepData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM steps WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}