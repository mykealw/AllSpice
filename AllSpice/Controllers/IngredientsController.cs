using System;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingrs;
        private readonly RecipesService _rs;

        public IngredientsController(IngredientsService ingrs, RecipesService rs)
        {
            _ingrs = ingrs;
            _rs = rs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                ingredientData.Creator = userInfo;
                Ingredient ingredient = _ingrs.CreateIngredient(ingredientData);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Edit(int id, [FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                ingredientData.Creator = userInfo;
                ingredientData.Id = id;
                Ingredient updated = _ingrs.Edit(ingredientData);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _ingrs.Delete(id, userInfo);
                return Ok("Deleted Ingredient");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}