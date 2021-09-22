using AutoMapper;
using MetricManager.DB;
using MetricManager.Dto;
using MetricManager.Entityes;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MetricManager.Controllers
{
    public class AgentController : ControllerBase
    {
        public Logger logger = LogManager.GetCurrentClassLogger();
        protected readonly IDbRepository _repository;
        protected readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;

        public AgentController(
            IDbRepository repository,
            IMapper mapper,
            IHttpClientFactory clientFactory
            )
        {
            _repository = repository;
            _mapper = mapper;
            _clientFactory = clientFactory;
        }

        [HttpGet("id/{id}/from/{from}/to/{to}")]
        public IActionResult GetDataFromControllerByIdAndDate([FromRoute] long id, [FromRoute] DateTime from, [FromRoute] DateTime to)
        {
            var uri = _repository.GetAgentUrlById(id);
            if (uri == null) return BadRequest();

            uri += $"/from/{from}/to/{to}";

            var client = _clientFactory.CreateClient();
            var result = client.GetAsync(uri).Result;

            if (result.IsSuccessStatusCode)
            {
                using var responseStream = result.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync
                    <List<DataFromAgentsDto>>(responseStream, new JsonSerializerOptions(JsonSerializerDefaults.Web)).Result;
                return Ok(metricsResponse);
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent(
            [FromBody] AgentDto dto)
        {
            var agent = _mapper.Map<AgentsEntity>(dto);

            if (_repository.CheckAgentIsExist(agent))
                return Ok("Агент уже создан, повтоное создание не требуется");

            var agentId = _repository.AddAgent(agent);
            if (agentId > 0) return Ok(agentId);

            return BadRequest();
        }

        [HttpGet("all")]
        public IQueryable<AgentsEntity> GetAllAgents()
        {
            return _repository.GetAgentsList();
        }

    }
}
