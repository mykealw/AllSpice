using Microsoft.AspNetCore.Mvc;
using AllSpice.Services;
using Microsoft.AspNetCore.Authorization;
using AllSpice.Models;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using System;

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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Step>> CreateStep([FromBody] Step StepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                StepData.Creator = userInfo;
                Step Step = _ss.CreateStep(StepData);
                return Ok(Step);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Step>> Edit(int id, [FromBody] Step StepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                StepData.Creator = userInfo;
                StepData.Id = id;
                Step updated = _ss.Edit(StepData);
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
                _ss.Delete(id, userInfo);
                return Ok("Deleted Step");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}