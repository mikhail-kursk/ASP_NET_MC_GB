using AutoMapper;
using MetricAgent.Entityes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.DB
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public DbRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetByPeriod(DateTime from, DateTime to)
        {
            return _context.Set<TEntity>().Where(x => x.Time > from && x.Time < to).AsQueryable();
        }
    }
}
