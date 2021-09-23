using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotnetController : BaseController<CpuEntity>
    {
        public DotnetController(
            IDbRepository<CpuEntity> repository,
            IMapper mapper
            ) : base (repository, mapper)
        { }
    }
}