using Microsoft.AspNetCore.Mvc;
using AllSpice.Services;

namespace AllSpice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepsController : ControllerBase
    {
        private readonly StepsService _ss;

        public StepsController(StepsService ss)
        {
            _ss = ss;
        }
    }
}