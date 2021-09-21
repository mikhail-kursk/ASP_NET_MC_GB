using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/ram")]
    public class RamController : BaseController<RamEntity>
    {
        public RamController(
            ILogger<BaseController<RamEntity>> logger,
            IDbRepository<RamEntity> repository,
            IMapper mapper
            ) : base(logger, repository, mapper)
        { }
    }
}