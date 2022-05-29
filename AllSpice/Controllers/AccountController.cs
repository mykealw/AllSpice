using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly FavoritesService _fs;

        public AccountController(AccountService accountService, FavoritesService fs)
        {
            _accountService = accountService;
            _fs = fs;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Favorites")]
        [Authorize]
        public async Task<ActionResult<List<FavoriteRecipeViewModel>>>GetFavoritesByAccount()
        {
           try
           {
               Account userinfo = await HttpContext.GetUserInfoAsync<Account>();
               List<FavoriteRecipeViewModel> recipes = _fs.GetFavoritesByAccount(userinfo.Id);
               return Ok(recipes);
           }
           catch(Exception e)
           {
               return BadRequest(e.Message);
           }
        }
    }


}