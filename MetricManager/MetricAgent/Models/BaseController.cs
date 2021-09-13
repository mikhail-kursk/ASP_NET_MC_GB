using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MetricAgent.Controllers
{
    public class BaseController : ControllerBase
    {

        public Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        public IActionResult Hi()
        {
            return Ok("Hi");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] string fromTime,[FromRoute] string toTime)
        {
            logger.Info($"fromTime = {fromTime}, toTime = {toTime}");
            return Ok();
        }
    }
}
