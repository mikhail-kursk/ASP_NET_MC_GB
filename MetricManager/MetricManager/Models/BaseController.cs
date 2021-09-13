using MetricManager.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MetricManager.Controllers
{
    public class BaseController : ControllerBase
    {
        public Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IActionResult Hi()
        {
            return Ok("Hi");
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            logger.Info($"agentInfo = {agentInfo}");
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            logger.Info($"agentId = {agentId}");
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            logger.Info($"agentId = {agentId}");
            return Ok();
        }
    }
}
