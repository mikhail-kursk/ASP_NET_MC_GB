using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/cpu")]
    public class CpuController : BaseController<CpuEntity>
    {
        public CpuController(
            ILogger<BaseController<CpuEntity>> logger,
            IDbRepository<CpuEntity> repository,
            IMapper mapper
            ) : base (logger, repository, mapper)
        { }
    }
}