using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MetricsAgent.Jobs
{
    public class CpuMetricJob : IJob
    {
        private PerformanceCounter _cpuCounter;
        private IServiceProvider _provider;

        public CpuMetricJob(IServiceProvider provider)
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            using (var scope = _provider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IDbRepository<CpuEntity>>();

                CpuEntity entity = new CpuEntity
                {
                    Value = Convert.ToInt32(_cpuCounter.NextValue()),
                    Time = DateTime.UtcNow
                };

                await repository.AddAsync(entity);
            }
        }
    }
}