using AllSpice.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingrs;

        public IngredientsController(IngredientsService ingrs)
        {
            _ingrs = ingrs;
        }
    }
}