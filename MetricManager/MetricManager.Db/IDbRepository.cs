using MetricManager.Entityes;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MetricManager.DB
{
    public interface IDbRepository 
    {
        long AddAgent(AgentsEntity entity);
        bool CheckAgentIsExist(AgentsEntity entity);
        IQueryable<AgentsEntity> GetAgentsList();
        string GetAgentUrlById(long id);
    }
}
