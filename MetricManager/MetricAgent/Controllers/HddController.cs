using MetricAgent.Logic;
using MetricAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddController : BaseController
    {
        private IHddMetricsRepository _repository;
        public HddController(
            ILogger<HddController> logger,
            IHddMetricsRepository repository) : base(logger)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            logger.LogInformation($"Time = {request.Time}, Value = {request.Value}");
            _repository.Create(new Metric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllMetricsResponse()
            {
                Metrics = new List<MetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new MetricDto { Time = metric.Time, Value = metric.Value, Id = metric.Id });
            }

            return Ok(response);
        }
    }
}