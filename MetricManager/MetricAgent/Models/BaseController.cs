using MetricAgent.Logic;
using MetricAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System.Data.SQLite;

namespace MetricAgent.Controllers
{
    public class BaseController : ControllerBase
    {

        protected readonly ILogger<BaseController> logger;

        public BaseController(ILogger<BaseController> logger)
        {
            this.logger = logger;
        }


        [HttpGet]
        public IActionResult Hi()
        {
            return Ok("Hi");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics([FromRoute] string fromTime,[FromRoute] string toTime)
        {
            logger.LogInformation($"fromTime = {fromTime}, toTime = {toTime}");
            return Ok();
        }

        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";

            using (var con = new SQLiteConnection(cs))
            {
                con.Open();

                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();

                return Ok(version);
            }
        }
    }
}
