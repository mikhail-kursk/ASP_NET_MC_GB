using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private PerformanceCounter _ramCounter;
        private IServiceProvider _provider;
        
        public RamMetricJob(IServiceProvider provider)
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            using (var scope = _provider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IDbRepository<RamEntity>>();

                RamEntity entity = new RamEntity
                {
                    Value = Convert.ToInt32(_ramCounter.NextValue()),
                    Time = DateTime.UtcNow
                };

                await repository.AddAsync(entity);
            }
        }
    }
}