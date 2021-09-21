﻿using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/hdd")]
    public class HddController : BaseController<HddEntity>
    {
        public HddController(
            ILogger<BaseController<HddEntity>> logger,
            IDbRepository<HddEntity> repository,
            IMapper mapper
            ) : base(logger, repository, mapper)
        { }
    }
}