using MetricAgent.Entityes;
using System.Linq;
using System.Threading.Tasks;

namespace MetricAgent.DB
{
    public interface IDbRepository<TEntity> where TEntity : BaseEntity 
    {
        IQueryable<TEntity> GetAll();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
    }
}
