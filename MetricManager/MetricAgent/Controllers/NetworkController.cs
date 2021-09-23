using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricAgent.Controllers
{
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkController : BaseController<NetworkEntity>
    {
        public NetworkController(
            IDbRepository<NetworkEntity> repository,
            IMapper mapper
            ) : base(repository, mapper)
        { }
    }
}