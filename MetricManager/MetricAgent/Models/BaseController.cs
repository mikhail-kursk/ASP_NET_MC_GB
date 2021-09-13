using Microsoft.AspNetCore.Mvc;

namespace MetricAgent.Controllers
{
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hi()
        {
            return Ok("Hi");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] string fromTime,[FromRoute] string toTime)
        {
            return Ok();
        }
    }
}
