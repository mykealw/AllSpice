using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AllSpice.Models;
using CodeWorks.Auth0Provider;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _fs;

        public FavoritesController(FavoritesService fs)
        {
            _fs = fs;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> Create([FromBody] Favorite favoriteData)
        {
            try
            {
                Account userinfo = await HttpContext.GetUserInfoAsync<Account>();
                favoriteData.AccountId = userinfo.Id;
                Favorite favorite = _fs.Create(favoriteData);
                favorite.Creator = userinfo;
                return Ok(favorite);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}