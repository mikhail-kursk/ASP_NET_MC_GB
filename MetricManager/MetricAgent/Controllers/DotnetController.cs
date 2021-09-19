using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/dotnet")]
    public class DotnetController : BaseController<DotnetEntity>
    {
        public DotnetController(
            ILogger<BaseController<DotnetEntity>> logger,
            IDbRepository<DotnetEntity> repository,
            IMapper mapper
            ) : base(logger, repository, mapper)
        { }
    }
}