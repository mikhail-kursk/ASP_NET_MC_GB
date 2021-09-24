using MetricAgent.Entityes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.DB
{
    public interface IDbRepository<TEntity> where TEntity : BaseEntity 
    {
        Task AddAsync(TEntity entity);
        IQueryable<TEntity> GetByPeriod(DateTime from, DateTime to);
    }
}
