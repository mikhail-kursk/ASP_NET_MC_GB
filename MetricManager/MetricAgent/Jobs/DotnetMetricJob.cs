using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MetricsAgent.Jobs
{
    public class DotnetMetricJob : IJob
    {
        private PerformanceCounter _dotnetCounter;
        private IServiceProvider _provider;

        public DotnetMetricJob(IServiceProvider provider)
        {
            _dotnetCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps", "_Global_");
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            using (var scope = _provider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IDbRepository<DotnetEntity>>();

                DotnetEntity entity = new DotnetEntity
                {
                    Value = Convert.ToInt32(_dotnetCounter.NextValue()),
                    Time = DateTime.UtcNow
                };

                await repository.AddAsync(entity);
            }
        }
    }
}