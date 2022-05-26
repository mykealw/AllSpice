using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

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



        
    }
}