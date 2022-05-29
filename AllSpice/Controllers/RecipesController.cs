using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _rs;
        private readonly FavoritesService _fs;
        private readonly IngredientsService _ingrs;
        private readonly StepsService _ss;

        public RecipesController(RecipesService rs, FavoritesService fs, IngredientsService ingrs, StepsService ss)
        {
            _rs = rs;
            _fs = fs;
            _ingrs = ingrs;
            _ss = ss;
        }

        //GETS SELF => RELATIONSHIPS

        [HttpGet]
        public ActionResult<List<Recipe>> GetRecipe()
        {
            try
            {
                List<Recipe> recipes = _rs.GetRecipe();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetById(int id)
        {
            try
            {
                Recipe recipe = _rs.GetById(id);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // RELATIONSHIPS 

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipe(int id)
        {
            try
            {
                List<Ingredient> ingredient = _rs.GetIngredientsByRecipe(id);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/steps")]
        public ActionResult<List<Step>> GetStepsByRecipe(int id)
        {
            try
            {
                List<Step> step = _rs.GetStepsByRecipe(id);
                return Ok(step);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POSTS

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
        {
            try
            {
                Account userinfo = await HttpContext.GetUserInfoAsync<Account>();
                recipeData.CreatorId = userinfo.Id;
                Recipe recipe = _rs.Create(recipeData);
                recipe.Creator = userinfo;
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUTS

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Recipe>> Edit(int id, [FromBody] Recipe recipeData)
        {
            try
            {
                Account userinfo = await HttpContext.GetUserInfoAsync<Account>();
                recipeData.CreatorId = userinfo.Id;
                recipeData.Id = id;
                Recipe recipe = _rs.Edit(recipeData);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETES

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _rs.Delete(id, userInfo.Id);
                return Ok("Recipe Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}