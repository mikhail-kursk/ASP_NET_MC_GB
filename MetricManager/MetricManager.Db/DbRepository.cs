using MetricManager.Entityes;
using System.Linq;
using System.Threading.Tasks;

namespace MetricManager.DB
{
    public class DbRepository : IDbRepository
    {
        private readonly AppDbContext _context;

        public DbRepository(AppDbContext context)
        {
            _context = context;
        }

        public long AddAgent(AgentsEntity entity)
        {
            _context.Clients.Add(entity);
            _context.SaveChanges();

            return _context.Clients.Where(x => x == entity).SingleOrDefault().Id;
        }

        public bool CheckAgentIsExist(AgentsEntity entity)
        {
            var agent = _context.Clients.Where(x => 
                x.ClientName == entity.ClientName &&
                x.Uri == entity.Uri
            ).SingleOrDefault();
            if (agent != null) return true;

            return false;
        }

        public IQueryable<AgentsEntity> GetAgentsList()
        {
            return _context.Clients.AsQueryable();
        }

        public string GetAgentUrlById(long id)
        {
            return _context.Clients.Where(x => x.Id == id).SingleOrDefault().Uri;
        }
    }
}
