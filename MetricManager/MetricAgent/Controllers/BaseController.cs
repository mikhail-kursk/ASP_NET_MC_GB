using AutoMapper;
using MetricAgent.DB;
using MetricAgent.Dto;
using MetricAgent.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.Controllers
{
    public abstract class BaseController<TEntity> : ControllerBase where TEntity: BaseEntity
    {

        protected readonly ILogger<BaseController<TEntity>> _logger;
        protected readonly IDbRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseController(
            ILogger<BaseController<TEntity>> logger, 
            IDbRepository<TEntity> repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet()]
        public IQueryable GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDto dto)
        {
            _logger.LogInformation($"dto = {dto}");
            await _repository.AddAsync(_mapper.Map<TEntity>(dto));
            return Ok();
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateDto dto)
        {
            _logger.LogInformation($"dto = {dto}");
            await _repository.UpdateAsync(_mapper.Map<TEntity>(dto));
            return Ok();
        }

        [HttpDelete()]
        public void Delete([FromBody] DeleteDto dto)
        {
            _logger.LogInformation($"dto = {dto}");
            _repository.Delete(_mapper.Map<TEntity>(dto));
        }
    }
}
