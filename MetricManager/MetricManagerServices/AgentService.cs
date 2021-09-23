using System;
using AutoMapper;
using MetricManager.DB;
using Microsoft.AspNetCore.Mvc;

namespace MetricManagerServices
{
    public class AgentService
    {
        private readonly IDbRepository _repository;
        protected readonly IMapper _mapper;

        public AgentService(
            IDbRepository repository,
            IMapper _mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult RegisterAgent()
        {
            var agentId = _repository.AddAgent(_mapper.Map<AgentsEntity>(dto));
            if (agentId > 0) return Ok(agentId);

            return BadRequest();
        }
    }
}
