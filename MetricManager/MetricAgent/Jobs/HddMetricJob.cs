using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private PerformanceCounter _hddCounter;
        private IServiceProvider _provider;

        public HddMetricJob(IServiceProvider provider)
        {
            _hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            using (var scope = _provider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IDbRepository<HddEntity>>();

                HddEntity entity = new HddEntity
                {
                    Value = Convert.ToInt32(_hddCounter.NextValue()),
                    Time = DateTime.UtcNow
                };

                await repository.AddAsync(entity);
            }
        }
    }
}