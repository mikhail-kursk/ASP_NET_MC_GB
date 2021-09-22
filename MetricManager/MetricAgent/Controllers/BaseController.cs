using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Dto;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricAgent.Controllers
{
    public abstract class BaseController<TEntity> : ControllerBase where TEntity: BaseEntity
    {

        protected readonly IDbRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseController(
            IDbRepository<TEntity> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("from/{from}/to/{to}")]
        public IEnumerable<SelectDto> GetByPeriod([FromRoute] DateTime from, [FromRoute] DateTime to)
        {
            return _mapper.Map<IEnumerable<SelectDto>>(_repository.GetByPeriod(from, to));
        }
    }
}
