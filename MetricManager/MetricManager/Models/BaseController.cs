using MetricManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetricManager.Controllers
{
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hi()
        {
            return Ok("Hi");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            return Ok();
        }
    }
}
