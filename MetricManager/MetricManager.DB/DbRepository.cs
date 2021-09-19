using AutoMapper;
using MetricAgent.Entityes;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.DB
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DbRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().FirstOrDefault().Remove(entity));
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            await _context.SaveChangesAsync();
        }
    }
}
